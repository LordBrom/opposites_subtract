using UnityEngine;

public class Level {

	// Interior
	public int width = 12;
	public int height = 10;

	public string levelText;
	public string nextLevel;

	public Vector2 spawn;
	public LevelObject[] levelObjects;
	public Vector2[] walls;

	public string SaveToString() {
		return JsonUtility.ToJson(this);
	}
	public void LoadFromJSON(string jsonString) {
		JsonUtility.FromJsonOverwrite(jsonString, this);
	}

	private void OnValidate() {
		int endCount = 0;
		for (int i = 0; i < levelObjects.Length; i++) {
			levelObjects[i].position.x = Mathf.Clamp(levelObjects[i].position.x, 1, width);
			levelObjects[i].position.y = Mathf.Clamp(levelObjects[i].position.y, 1, height);

			if (levelObjects[i].levelObjectType == LevelObjectType.LevelEnd || levelObjects[i].hasLevelEnd) {
				endCount++;
			}
		}
		for (int i = 0; i < walls.Length; i++) {
			walls[i].x = Mathf.Clamp(walls[i].x, 1, width);
			walls[i].y = Mathf.Clamp(walls[i].y, 1, height);
		}

		if (endCount < 1) {
			Debug.LogWarning("Level must have one end point");
		}
	}
}

[System.Serializable]
public struct LevelObject {
	public LevelObjectType levelObjectType;
	public string collisionID;
	public ObjectPair objectPair;
	public bool hasLevelEnd;
	public Vector2 position;
}

public enum LevelObjectType {
	Spawn,
	LevelEnd,
	Object,
	DeathTile,
	InverseSpawn,
	FakeWall,
}
