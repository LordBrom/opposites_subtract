using System.IO;
using System.Collections.Generic;
using UnityEngine;


public static class LevelSaveLoad {
	#region Variables

	private static string rootLevelPath = Application.dataPath + "/Levels/";

	#endregion

	public static void SaveLevelJson(Level level, string levelName) {
		if (!levelName.Contains(".json")) {
			levelName += ".json";
		}
		string levelJson = JsonUtility.ToJson(level);
		File.WriteAllText(rootLevelPath + levelName, levelJson);
	}

	public static Level LoadLevelJson(string levelName) {
		if (!levelName.Contains(".json")) {
			levelName += ".json";
		}
		return new Level(File.ReadAllText(rootLevelPath + levelName));
	}

	public static void LoadLevelJson(string levelName, out Level level) {
		level = LoadLevelJson(levelName);
	}

	public static List<Level> LoadLevelFolder(bool customLevels = false) {
		List<Level> levels = new List<Level>();


		FileInfo[] files = new DirectoryInfo(rootLevelPath).GetFiles();

		foreach (FileInfo file in files) {
			if (file.Extension == ".json") {
				levels.Add(LevelSaveLoad.LoadLevelJson(file.Name));
			}
		}

		return levels;
	}
}
