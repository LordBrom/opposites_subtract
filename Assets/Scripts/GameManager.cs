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
		SceneManager.sceneLoaded += startGame;
	}
	#endregion

	#region Inspector Assignments

	public SoundManager soundManager;
	public LevelManager levelManager;
	public LevelBuilder levelBuilder;
	public LevelOverMenu levelOverMenu;
	public PauseMenu pauseMenu;
	public ThanksMenu thanksMenu;
	public DeathMenu deathMenu;

	#endregion
	#region Variables

	private Level level;
	public bool levelActive;

	#endregion

	#region Unity Methods
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pauseMenu.toggleMenu();
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			reloadLevel();
		}
	}
	#endregion

	public void startGame(Scene S, LoadSceneMode mode) {
		SceneManager.sceneLoaded -= startGame;
		nextLevel();
	}

	public void endLevel() {
		if (levelActive) {
			levelActive = false;
			soundManager.playLevelWin();
			levelOverMenu.showMenu();
		}
	}

	public void showDeathMenu() {
		if (levelActive) {
			levelActive = false;
			soundManager.playLevelLoose();
			deathMenu.showMenu();
		}
	}

	public void reloadLevel() {
		levelOverMenu.hideMenu();
		deathMenu.hideMenu();
		levelBuilder.buildLevel(level);
		levelActive = true;
	}

	public void nextLevel() {
		level = levelManager.getNextLevel();
		if (level != null) {
			levelBuilder.buildLevel(level);
			levelActive = true;
			levelOverMenu.hideMenu();
		} else {
			showThanksMenu();
		}
	}

	public void goToMainMenu() {
		SceneManager.LoadScene(0);
	}

	public void showThanksMenu() {
		thanksMenu.showMenu();
	}
}
