using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class LevelSaveLoad {

	#region Inspector Assignments

	#endregion
	#region Variables

	private static string rootLevelPath = Application.dataPath + "/Levels/";

	#endregion

	public static void SaveLevelJson(Level level, string levelName) {
		string levelJson = JsonUtility.ToJson(level);
		Debug.Log(levelJson);
		Debug.Log(Application.persistentDataPath);
		System.IO.File.WriteAllText(Application.persistentDataPath + "/" + levelName + ".json", levelJson);
	}

	public static string LoadLevelJson(string levelName) {
		return System.IO.File.ReadAllText(rootLevelPath + levelName + ".json");
	}
}
