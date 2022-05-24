using UnityEngine;

public class MainMenu : MonoBehaviour {

	private void Start() {
		LevelManager.LoadLevels();
	}

	[SerializeField]
	private LevelSelectMenu levelSelectMenu;

	public void StartGame() {
		levelSelectMenu.ShowLevelSelectMenu();
	}

	public void LevelEditor() {
		levelSelectMenu.ShowLevelSelectMenu();
	}

	public void QuitGame() {
		Application.Quit();
	}

}
