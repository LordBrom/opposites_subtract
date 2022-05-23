using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	#region Singleton
	public static GameManager instance;

	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		SceneManager.sceneLoaded += StartGame;
	}
	#endregion

	#region Inspector Assignments

	public SoundManager soundManager;
	public LevelBuilder levelBuilder;

	public LevelOverMenu levelOverMenu;
	public PauseMenu pauseMenu;
	public ThanksMenu thanksMenu;
	public DeathMenu deathMenu;

	#endregion
	#region Variables

	public Level level;
	public bool levelActive { get; private set; }

	#endregion

	#region Unity Methods
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pauseMenu.ToggleMenu();
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			LoadLevel();
		}
	}
	#endregion

	public void StartGame(Scene S, LoadSceneMode mode) {
		SceneManager.sceneLoaded -= StartGame;
		level = LevelManager.activeLevel;
		LoadLevel();
	}

	public void EndLevel() {
		if (levelActive) {
			levelActive = false;
			soundManager.PlayLevelWin();
			levelOverMenu.ShowMenu();
		}
	}

	public void ShowDeathMenu() {
		if (levelActive) {
			levelActive = false;
			soundManager.PlayLevelLoose();
			deathMenu.ShowMenu();
		}
	}

	public void LoadLevel() {
		levelOverMenu.HideMenu();
		deathMenu.HideMenu();
		levelBuilder.BuildLevel(level);
		levelActive = true;
	}

	public void NextLevel() {
		this.level = LevelManager.GetNextLevel();
		if (this.level == null) {
			ShowThanksMenu();
		} else {
			LoadLevel();
		}
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene(0);
	}

	public void ShowThanksMenu() {
		thanksMenu.ShowMenu();
	}

}
