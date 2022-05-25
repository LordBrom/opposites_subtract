using UnityEngine;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private LevelSelectMenu levelSelectMenu;

	public void StartGame() {
		LevelManager.loadCustom = false;
		levelSelectMenu.ShowLevelSelectMenu();
	}

	public void LevelEditor() {
		LevelManager.loadCustom = true;
		levelSelectMenu.ShowLevelSelectMenu(true);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
