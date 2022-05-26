using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : HideableMenu {

	#region Inspector Assignments

	[SerializeField]
	private Transform levelListing;
	[SerializeField]
	private GameObject levelListItemPrefab;

	#endregion
	#region Variables

	private List<GameObject> loadedLevels;

	#endregion

	#region Unity Methods
	protected override void Start() {
		base.Start();

		loadedLevels = new List<GameObject>();
	}
	#endregion

	public void ShowLevelSelectMenu(bool forEditor = false) {
		LevelManager.LoadLevels(reload: true);
		foreach (GameObject levelObject in loadedLevels) {
			Destroy(levelObject);
		}
		loadedLevels.Clear();
		this.LoadLevelListingItems(LevelManager.customLevels);
		if (!forEditor) {
			this.LoadLevelListingItems(LevelManager.levels);
		}
		this.ShowMenu();
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
}
