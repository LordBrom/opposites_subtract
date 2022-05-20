using UnityEngine;

public class Reactor : Collidable {

	#region Inspector Assignments

	public string collisionID;
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
		pushSound.volume = GameManager.instance.soundManager.GetEffectVolume();
		base.Update();
	}

	private void OnValidate() {
	}

	#endregion

	protected override void OnCollide(Collider2D coll) {
		Reactor otherReactor = coll.gameObject.GetComponent<Reactor>();

		if (otherReactor != null) {
			if (this.collisionID == otherReactor.collisionID) {
				if (this.hasLevelEnd) {
					GameManager.instance.levelBuilder.AddLevelEnd(transform.position);
				} else if (otherReactor.hasLevelEnd) {
					GameManager.instance.levelBuilder.AddLevelEnd(otherReactor.transform.position);
				}
				Destroy(gameObject);
				Destroy(coll.gameObject);
			}
		}
	}

	public virtual void setBlockData(LevelObject levelObject) {
		this.collisionID = levelObject.collisionID;
		this.name = levelObject.objectPair.name;
		this.hasLevelEnd = levelObject.hasLevelEnd;
		gameObject.GetComponent<SpriteRenderer>().sprite = levelObject.objectPair.sprite;
	}

	void PlayPushSound() {
		float fromSeconds = soundRange.x;
		float toSeconds = soundRange.y;

		pushSound.time = fromSeconds;
		pushSound.Play();
		pushSound.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}
}
