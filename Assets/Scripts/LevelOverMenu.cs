using UnityEngine;

public class LevelOverMenu : HideableMenu {

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
