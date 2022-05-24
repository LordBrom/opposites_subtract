using UnityEngine;

public class DeathMenu : HideableMenu {

	public void MainMenu() {
		GoToMainMenu();
	}

	public void ReloadLevel() {
		GameManager.instance.LoadLevel();
	}
}
