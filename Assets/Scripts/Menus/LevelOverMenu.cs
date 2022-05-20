using UnityEngine;

public class LevelOverMenu : HideableMenu {

	private void Update() {
		if (showing && Input.GetKeyDown(KeyCode.E)) {
			NextLevel();
		}
	}

	public void MainMenu() {
		GameManager.instance.GoToMainMenu();
	}

	public void ReloadLevel() {
		GameManager.instance.ReloadLevel();
	}

	public void NextLevel() {
		GameManager.instance.NextLevel();
	}
}
