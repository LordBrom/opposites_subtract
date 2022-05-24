using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public static class LevelSaveLoad {
	#region Variables

	private static string rootLevelPath = Application.dataPath + "/Levels/";
	private static string mainLevelPath = LevelSaveLoad.rootLevelPath + "Main/";
	private static string customLevelPath = LevelSaveLoad.rootLevelPath + "Custom/";

	#endregion

	public static void SaveLevelJson(Level level) {
		string filePath = LevelSaveLoad.GetFilePath(level);
		string levelJson = JsonUtility.ToJson(level);
		File.WriteAllText(filePath, levelJson);
	}

	public static Level LoadLevelJson(string levelName, bool isCustom = true) {
		string filePath = LevelSaveLoad.GetFilePath(levelName, isCustom, false);
		return new Level(File.ReadAllText(filePath));
	}

	public static List<Level> LoadLevelFolder(bool customLevels = false) {
		List<Level> levels = new List<Level>();

		FileInfo[] files = new DirectoryInfo(customLevels ? LevelSaveLoad.customLevelPath : LevelSaveLoad.mainLevelPath).GetFiles();

		foreach (FileInfo file in files) {
			if (file.Extension == ".json") {
				levels.Add(LevelSaveLoad.LoadLevelJson(file.Name));
			}
		}

		return levels;
	}

	public static string GetFilePath(Level level, bool cleanName = true) {
		return GetFilePath(level.name, level.isCustom, cleanName);
	}
	public static string GetFilePath(string levelName, bool isCustom = true, bool cleanName = true) {
		string filePath = isCustom ? LevelSaveLoad.customLevelPath : LevelSaveLoad.mainLevelPath;
		if (cleanName) {
			levelName = Regex.Replace(levelName, "[^0-9a-zA-Z_ ]", "");
			levelName = levelName.Replace(" ", "_");
		}
		if (!levelName.Contains(".json")) {
			levelName += ".json";
		}
		return filePath + levelName;
	}
}
