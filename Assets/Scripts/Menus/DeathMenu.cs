using UnityEngine;

public class DeathMenu : HideableMenu {

	public void MainMenu() {
		GameManager.instance.GoToMainMenu();
	}

	public void ReloadLevel() {
		GameManager.instance.ReloadLevel();
	}
}
