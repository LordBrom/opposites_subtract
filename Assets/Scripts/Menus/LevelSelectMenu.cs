using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : HideableMenu {

	#region Inspector Assignments

	[SerializeField]
	private Transform levelListing;
	[SerializeField]
	private GameObject levelListItemPrefab;
	[SerializeField]
	private GameObject newLevelButton;
	[SerializeField]
	private GameObject levelToggleButton;

	#endregion
	#region Variables

	private List<GameObject> loadedLevels;
	private bool showingCustom;
	private Text levelToggleButtonText;

	#endregion

	#region Unity Methods
	protected override void Start() {
		base.Start();

		loadedLevels = new List<GameObject>();
		levelToggleButtonText = levelToggleButton.GetComponentInChildren<Text>();
	}
	#endregion

	public void ShowLevelSelectMenu(bool forEditor = false) {
		LevelManager.LoadLevels(reload: true);
		this.showingCustom = forEditor;
		this.LoadLevels();

		if (forEditor) {
			newLevelButton.SetActive(true);
			levelToggleButton.SetActive(false);
		} else {
			newLevelButton.SetActive(false);
			levelToggleButton.SetActive(true);
		}

		this.ShowMenu();
	}

	private void ClearLevelListing() {
		foreach (GameObject levelObject in loadedLevels) {
			Destroy(levelObject);
		}
		loadedLevels.Clear();
	}

	private void LoadLevels(bool clearFirst = true) {
		if (clearFirst) {
			ClearLevelListing();
		}
		this.LoadLevelListingItems(this.showingCustom ? LevelManager.customLevels : LevelManager.levels);
	}

	private void LoadLevelListingItems(Level[] levels) {
		foreach (Level level in levels) {
			GameObject levelListItemObject = Instantiate(levelListItemPrefab, levelListing);
			levelListItemObject.GetComponent<LevelListItem>().SetLevelData(level);
			loadedLevels.Add(levelListItemObject);
		}
	}

	public void HideLevelSelectMenu() {
		this.HideMenu();
	}

	public void NewLevelButton() {
		LevelManager.SetLevel(new Level(isCustom: true));
		SceneManager.LoadScene(2);
	}

	public void ToggleLevelListing() {
		this.showingCustom = !this.showingCustom;
		this.LoadLevels();
		if (this.showingCustom) {
			this.levelToggleButtonText.text = "Show Main";
		} else {
			this.levelToggleButtonText.text = "Show Custom";
		}
	}
}
