using UnityEngine;

public class Reactor : Collidable {

	#region Inspector Assignments

	public int collisionGroupNum;
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
			if (this.collisionGroupNum == otherReactor.collisionGroupNum) {
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
		this.collisionGroupNum = levelObject.collisionGroupNum;
		this.name = levelObject.name;
		this.hasLevelEnd = levelObject.hasLevelEnd;
		this.levelObject = levelObject;
		this.editMode = editMode;
		gameObject.GetComponent<SpriteRenderer>().sprite = levelObject.sprite;
	}

	public void ToggleHasLevelEnd() {
		if (this.hasLevelEnd) {
			this.hasLevelEnd = false;
		} else {
			this.hasLevelEnd = true;
		}
		this.levelObject.hasLevelEnd = this.hasLevelEnd;
	}

	public void SetCollisionGroupNum(int change, int groupCount = 10) {
		this.collisionGroupNum += change;
		this.collisionGroupNum %= groupCount;
		if (this.collisionGroupNum < 0) {
			this.collisionGroupNum = groupCount - 1;
		}
		this.levelObject.collisionGroupNum = this.collisionGroupNum;
	}

	void PlayPushSound() {
		float fromSeconds = soundRange.x;
		float toSeconds = soundRange.y;

		pushSound.time = fromSeconds;
		pushSound.Play();
		pushSound.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}
}
