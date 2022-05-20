using UnityEngine;

public class PauseMenu : HideableMenu {

	public HideableMenu mainPauseMenu;
	public HideableMenu optionsMenu;

	protected override void Start() {
		base.Start();
		mainPauseMenu.ShowMenu();
	}

	public void ResumeGame() {
		HideMenu();
	}

	public void MainMenu() {
		GameManager.instance.GoToMainMenu();
	}

	public void QuiteGame() {
		Application.Quit();
	}

	public void ShowOptions() {
		mainPauseMenu.HideMenu();
		optionsMenu.ShowMenu();
	}
	public void ShowMainPause() {
		optionsMenu.HideMenu();
		mainPauseMenu.ShowMenu();
	}

	public override void ToggleMenu() {
		ShowMainPause();
		base.ToggleMenu();
	}
}
