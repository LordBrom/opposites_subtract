using UnityEngine;

public static class LevelManager {
	#region Variables

	public static Level[] levels;
	public static Level[] customLevels;
	public static Level level { get; private set; }
	private static bool isCustom;
	private static int currentLevel = -1;
	private static bool levelsLoaded;

	#endregion

	public static void LoadLevels(bool reload = false) {
		if (!LevelManager.levelsLoaded || reload) {
			LevelManager.levels = LevelSaveLoad.LoadLevelFolder().ToArray();
			LevelManager.customLevels = LevelSaveLoad.LoadLevelFolder(true).ToArray();
			LevelManager.levelsLoaded = true;
		}
	}

	public static void SetLevel(Level level) {
		if (level.isCustom) {

		}
	}

	public static bool SetNextLevel() {
		if (LevelManager.isCustom) {
			return false;
		}
		LevelManager.currentLevel++;
		if (LevelManager.currentLevel < LevelManager.levels.Length) {
			LevelManager.level = LevelManager.levels[currentLevel];
			return true;
		}
		return false;
	}

	public static Level GetNextLevel() {
		if (LevelManager.isCustom) {
			return null;
		}
		currentLevel++;
		if (currentLevel < levels.Length) {
			return levels[currentLevel];
		}
		return null;
	}


}
