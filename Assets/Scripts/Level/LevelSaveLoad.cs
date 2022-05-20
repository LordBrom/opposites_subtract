using UnityEngine;


public static class LevelSaveLoad {
	#region Variables

	private static string rootLevelPath = Application.dataPath + "/Levels/";

	#endregion

	public static void SaveLevelJson(Level level, string levelName) {
		string levelJson = JsonUtility.ToJson(level);
		System.IO.File.WriteAllText(rootLevelPath + levelName + ".json", levelJson);
	}

	public static string LoadLevelJson(string levelName) {
		return System.IO.File.ReadAllText(rootLevelPath + levelName + ".json");
	}
}
