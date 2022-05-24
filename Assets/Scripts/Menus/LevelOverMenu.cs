using UnityEngine;

public class LevelOverMenu : HideableMenu {

	protected override void Update() {
		if (showing && Input.GetKeyDown(KeyCode.E)) {
			NextLevel();
		}
	}

	public void MainMenu() {
		GoToMainMenu();
	}

	public void ReloadLevel() {
		LevelPlayer.instance.LoadLevel();
	}

	public void NextLevel() {
		LevelPlayer.instance.NextLevel();
	}
}
