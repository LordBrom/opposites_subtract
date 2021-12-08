using UnityEngine;

public class PauseMenu : HideableMenu {

	public HideableMenu mainPauseMenu;
	public HideableMenu optionsMenu;

	protected override void Start() {
		base.Start();
		mainPauseMenu.showMenu();
	}

	public void resumeGame() {
		hideMenu();
	}

	public void mainMenu() {
		GameManager.instance.goToMainMenu();
	}

	public void quiteGame() {
		Application.Quit();
	}

	public void showOptions() {
		mainPauseMenu.hideMenu();
		optionsMenu.showMenu();
	}
	public void showMainPause() {
		optionsMenu.hideMenu();
		mainPauseMenu.showMenu();
	}

	public override void toggleMenu() {
		showMainPause();
		base.toggleMenu();
	}
}
