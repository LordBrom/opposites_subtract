using UnityEngine;

public class GameManager : MonoBehaviour {

	#region Singleton
	public static GameManager instance;

	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	#region Inspector Assignments

	public LevelBuilder levelBuilder;
	public LevelOverMenu levelOverMenu;
	public Level level;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	void Start() {
		levelBuilder.buildLevel(level);
		levelOverMenu.hideMenu();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			reloadLevel();
		}
	}
	#endregion

	public void endLevel() {
		levelOverMenu.showMenu();
	}

	public void reloadLevel() {
		levelOverMenu.hideMenu();
		levelBuilder.buildLevel(level);
	}

	public void nextLevel() {
		Debug.Log("Next Level");
	}

	public void levelSelect() {
		Debug.Log("Back to Level Select"); // probably just a scene
	}
}
