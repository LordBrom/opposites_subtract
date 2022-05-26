using UnityEngine;

public class Reactor : Collidable {

	#region Inspector Assignments

	[SerializeField]
	private GameObject endLevelIndicator;

	public string collisionID;
	public Vector2 soundRange;

	#endregion
	#region Variables

	public bool hasLevelEnd;
	public bool editMode;

	private AudioSource pushSound;
	private Vector3 lastPosition;
	private LevelObject levelObject;

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
		pushSound.volume = SoundManager.instance.GetEffectVolume();
		base.Update();
	}

	protected override void OnCollide(Collider2D coll) {
		Reactor otherReactor = coll.gameObject.GetComponent<Reactor>();

		if (otherReactor != null) {
			if (this.collisionID == otherReactor.collisionID) {
				if (this.hasLevelEnd) {
					LevelPlayer.instance.AddLevelEnd(transform.position);
				} else if (otherReactor.hasLevelEnd) {
					LevelPlayer.instance.AddLevelEnd(otherReactor.transform.position);
				}
				Destroy(gameObject);
				Destroy(coll.gameObject);
			}
		}
	}
	#endregion

	public virtual void setBlockData(LevelObject levelObject, bool editMode = false) {
		this.collisionID = levelObject.collisionID;
		this.name = levelObject.name;
		this.hasLevelEnd = levelObject.hasLevelEnd;
		this.levelObject = levelObject;
		this.editMode = editMode;
		gameObject.GetComponent<SpriteRenderer>().sprite = levelObject.sprite;

		if (editMode) {
			endLevelIndicator.SetActive(true);
		} else {
			endLevelIndicator.SetActive(false);
		}
	}

	public void ToggleHasLevelEnd() {
		if (this.hasLevelEnd) {
			this.hasLevelEnd = false;
		} else {
			this.hasLevelEnd = true;
		}
		this.levelObject.hasLevelEnd = this.hasLevelEnd;
	}

	void PlayPushSound() {
		float fromSeconds = soundRange.x;
		float toSeconds = soundRange.y;

		pushSound.time = fromSeconds;
		pushSound.Play();
		pushSound.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}
}
