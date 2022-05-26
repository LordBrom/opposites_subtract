using UnityEngine;

public class LevelPlayer : LevelBuilder {

	#region Singleton
	public static LevelPlayer instance;

	protected override void Awake() {
		base.Awake();
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	#region Inspector Assignments

	[SerializeField]
	private LevelOverMenu levelOverMenu;
	[SerializeField]
	private ThanksMenu thanksMenu;
	[SerializeField]
	private DeathMenu deathMenu;

	#endregion
	#region Variables

	public Level level;
	public bool levelActive { get; private set; }

	#endregion

	#region Unity Methods
	private void Start() {
		this.level = LevelManager.level;
		this.LoadLevel();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			LoadLevel();
		}
	}
	#endregion

	public void EndLevel() {
		if (levelActive) {
			this.levelActive = false;
			SoundManager.instance.PlayLevelWin();
			this.levelOverMenu.ShowMenu();
		}
	}

	public void ShowDeathMenu() {
		if (levelActive) {
			this.levelActive = false;
			SoundManager.instance.PlayLevelLose();
			this.deathMenu.ShowMenu();
		}
	}

	public void LoadLevel() {
		this.levelOverMenu.HideMenu();
		this.deathMenu.HideMenu();
		this.BuildLevel(level);
		this.levelActive = true;
	}

	public void NextLevel() {
		this.level = LevelManager.GetNextLevel();
		if (this.level == null) {
			this.ShowThanksMenu();
		} else {
			this.LoadLevel();
		}
	}

	public void ShowThanksMenu() {
		this.thanksMenu.ShowMenu();
	}
}
