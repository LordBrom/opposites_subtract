using System.Collections.Generic;
using UnityEngine;

public class Level {
	public string name;

	// Interior
	public int width = 12;
	public int height = 10;

	public string levelText;
	public string nextLevel;

	public bool isCustom { get; private set; }

	public Vector2 spawn;
	public List<LevelObject> levelObjects;
	public List<Vector2> walls;

	public Level() {
		levelObjects = new List<LevelObject>();
		walls = new List<Vector2>();
		spawn = new Vector2(0, 0);
	}

	public Level(string levelJson) {
		levelObjects = new List<LevelObject>();
		walls = new List<Vector2>();
		spawn = new Vector2(0, 0);
		this.LoadFromJSON(levelJson);
	}

	public string SaveToString() {
		return JsonUtility.ToJson(this);
	}
	public void LoadFromJSON(string jsonString) {
		JsonUtility.FromJsonOverwrite(jsonString, this);
	}

	private void OnValidate() {
		int endCount = 0;
		foreach (LevelObject levelObject in this.levelObjects) {
			if (levelObject.type == LevelObject.Type.LevelEnd || levelObject.hasLevelEnd) {
				endCount++;
			}
		}

		if (endCount < 1) {
			Debug.LogWarning("Level must have one end point");
		}
	}

	public void ToggleWall(Vector2 wallPosition) {
		if (this.walls.Contains(wallPosition)) {
			this.RemoveWall(wallPosition);
		} else {
			this.AddWall(wallPosition);
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
