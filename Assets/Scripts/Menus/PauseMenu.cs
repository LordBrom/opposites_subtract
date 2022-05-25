using UnityEngine;

public class PauseMenu : HideableMenu {

	public HideableMenu mainPauseMenu;
	public HideableMenu optionsMenu;

	protected override void Start() {
		base.Start();
		mainPauseMenu.ShowMenu();
	}

	protected override void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			this.ToggleMenu();
		}
	}

	public void ResumeGame() {
		HideMenu();
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
		base.ToggleMenu();
		ShowMainPause();
	}
}
