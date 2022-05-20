using System.Collections.Generic;
using UnityEngine;

public class Level {

	// Interior
	public int width = 12;
	public int height = 10;

	public string levelText;
	public string nextLevel;

	public Vector2 spawn;
	public LevelObject[] levelObjects;
	public List<Vector2> walls;

	public Level() {
		walls = new List<Vector2>();
	}

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

		if (endCount < 1) {
			Debug.LogWarning("Level must have one end point");
		}
	}

	public void AddWall(Vector2 wallPosition) {
		if (!walls.Contains(wallPosition)) {
			walls.Add(wallPosition);
		}
	}

	public void RemoveWall(Vector2 wallPosition) {
		if (walls.Contains(wallPosition)) {
			walls.Remove(wallPosition);
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
