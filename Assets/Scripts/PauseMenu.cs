using UnityEngine;

public class PauseMenu : HideableMenu {

	public void resumeGame() {
		hideMenu();
	}

	public void mainMenu() {
		GameManager.instance.goToMainMenu();
	}

	public void quiteGame() {
		Application.Quit();
	}
}
