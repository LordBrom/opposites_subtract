using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : HideableMenu {

	#region Inspector Assignments

	[SerializeField]
	private Transform levelListing;
	[SerializeField]
	private GameObject levelListItemPrefab;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	protected override void Start() {
		base.Start();
	}

	void Update() {

	}
	#endregion

	public void ShowLevelSelectMenu(bool customOnly = false) {
		if (customOnly) {

		}
		//List<Level> customLevels = LevelSaveLoad.LoadLevelFolder();

		foreach (Level level in LevelManager.levels) {
			Instantiate(levelListItemPrefab, levelListing).GetComponent<LevelListItem>().SetLevelData(level);
		}

		this.ShowMenu();
	}

	public void HideLevelSelectMenu() {
		this.HideMenu();
	}
}
