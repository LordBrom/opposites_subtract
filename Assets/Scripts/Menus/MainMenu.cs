using UnityEngine;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private LevelSelectMenu levelSelectMenu;

	public void StartGame() {
		LevelManager.loadEditor = false;
		levelSelectMenu.ShowLevelSelectMenu();
	}

	public void LevelEditor() {
		LevelManager.loadEditor = true;
		levelSelectMenu.ShowLevelSelectMenu(true);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
