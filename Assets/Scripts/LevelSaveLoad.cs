using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelSaveLoad {

	#region Inspector Assignments

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	void Start() {

	}

	void Update() {

	}
	#endregion

	public void SaveLevelAsJson(Level level, string levelName) {
		string levelJson = JsonUtility.ToJson(level);
		Debug.Log(levelJson);
		Debug.Log(Application.persistentDataPath);
		System.IO.File.WriteAllText(Application.persistentDataPath + "/" + levelName + ".json", levelJson);
	}

	public LevelCustom LoadLevelFromJson(string levelName) {
		string levelJson = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + levelName + ".json");
		return Newtonsoft.Json.JsonConvert.DeserializeObject<LevelCustom>(levelJson);
	}
}
