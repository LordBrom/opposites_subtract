using UnityEngine;

public class LevelOverMenu : HideableMenu {

	private void Update() {
		if (showing && Input.GetKeyDown(KeyCode.E)) {
			nextLevel();
		}
	}

	public void mainMenu() {
		GameManager.instance.goToMainMenu();
	}

	public void reloadLevel() {
		GameManager.instance.reloadLevel();
	}

	public void nextLevel() {
		GameManager.instance.nextLevel();
	}
}
