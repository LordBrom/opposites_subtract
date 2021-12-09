using UnityEngine;

public class DeathMenu : HideableMenu {

	public void mainMenu() {
		GameManager.instance.goToMainMenu();
	}

	public void reloadLevel() {
		GameManager.instance.reloadLevel();
	}
}
