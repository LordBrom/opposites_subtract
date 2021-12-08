using UnityEngine;

public class Reactor : Collidable {

	#region Inspector Assignments

	public ObjectPair objectPair;
	public Vector2 soundRange;

	#endregion
	#region Variables

	public bool hasLevelEnd;

	private AudioSource pushSound;
	private Vector3 lastPosition;

	#endregion

	#region Unity Methods

	protected override void Start() {
		pushSound = GetComponent<AudioSource>();
		lastPosition = transform.position;
		base.Start();
	}

	protected override void Update() {
		if (transform.position != lastPosition && !pushSound.isPlaying) {
			PlayPushSound();
		}
		lastPosition = transform.position;
		pushSound.volume = GameManager.instance.soundManager.getEffectVolume();
		base.Update();
	}

	private void OnValidate() {
		if (objectPair != null) {
			setBlockData(ScriptableObject.Instantiate(objectPair));
		}
	}

	#endregion

	protected override void onCollide(Collider2D coll) {
		Reactor otherReactor = coll.gameObject.GetComponent<Reactor>();

		if (otherReactor != null) {
			if (objectPair.reactsWithList().Contains(otherReactor.objectPair)) {
				if (hasLevelEnd) {
					GameManager.instance.levelBuilder.addLevelEnd(transform.position);
				} else if (otherReactor.hasLevelEnd) {
					GameManager.instance.levelBuilder.addLevelEnd(otherReactor.transform.position);
				}
				Destroy(gameObject);
				Destroy(coll.gameObject);
			}
		}
	}

	public virtual void setBlockData(ObjectPair blockData, bool _hasLevelEnd = false) {
		objectPair = blockData;
		name = blockData.name;
		hasLevelEnd = _hasLevelEnd;
		gameObject.GetComponent<SpriteRenderer>().sprite = blockData.sprite;
	}

	void PlayPushSound() {
		float fromSeconds = soundRange.x;
		float toSeconds = soundRange.y;

		pushSound.time = fromSeconds;
		pushSound.Play();
		pushSound.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}
}
