using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Custom/Level")]
public class Level : ScriptableObject {

	// Interior
	public int height = 10;
	public int width = 12;

	public LevelObject[] levelObjects;

	private void OnValidate() {
		int spawnCount = 0;
		int endCount = 0;
		for (int i = 0; i < levelObjects.Length; i++) {
			levelObjects[i].x = Mathf.Clamp(levelObjects[i].x, 1, width);
			levelObjects[i].y = Mathf.Clamp(levelObjects[i].y, 1, height);

			if (levelObjects[i].levelObjectType == LevelObjectType.Spawn) {
				spawnCount++;
			}
			if (levelObjects[i].levelObjectType == LevelObjectType.LevelEnd) {
				endCount++;
			}
		}

		if (spawnCount > 1) {
			Debug.LogError("Level can only contain one spawn point.");
		}
		if (spawnCount < 1) {
			Debug.LogWarning("Level must have one spawn point");
		}
		if (endCount < 1) {
			Debug.LogWarning("Level must have one end point");
		}
	}
}

[System.Serializable]
public struct LevelObject {
	public LevelObjectType levelObjectType;
	public ObjectPair objectPair;
	public int x;
	public int y;
}

public enum LevelObjectType {
	Wall,
	Spawn,
	LevelEnd,
	Object
}
