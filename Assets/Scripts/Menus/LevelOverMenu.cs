using UnityEngine;

public class LevelOverMenu : HideableMenu {

	private void Update() {
		if (showing && Input.GetKeyDown(KeyCode.E)) {
			NextLevel();
		}
	}

	public void MainMenu() {
		GoToMainMenu();
	}

	public void ReloadLevel() {
		GameManager.instance.LoadLevel();
	}

	public void NextLevel() {
		GameManager.instance.NextLevel();
	}
}
