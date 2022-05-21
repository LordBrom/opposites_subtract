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

	private Level level;
	public bool levelActive { get; private set; }

	#endregion

	#region Unity Methods
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pauseMenu.ToggleMenu();
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			ReloadLevel();
		}
	}
	#endregion

	public void StartGame(Scene S, LoadSceneMode mode) {
		SceneManager.sceneLoaded -= StartGame;
		level = new Level();
		NextLevel();
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

	public void ReloadLevel() {
		levelOverMenu.HideMenu();
		deathMenu.HideMenu();
		levelBuilder.BuildLevel(level);
		levelActive = true;
	}

	public void NextLevel() {
		string nextLevelJson = LevelSaveLoad.LoadLevelJson("New_Level");
		level.LoadFromJSON(nextLevelJson);

		if (level != null) {
			levelBuilder.BuildLevel(level);
			levelActive = true;
			levelOverMenu.HideMenu();
		} else {
			ShowThanksMenu();
		}
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene(0);
	}

	public void ShowThanksMenu() {
		thanksMenu.ShowMenu();
	}
}
