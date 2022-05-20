using UnityEngine;

public class LevelCustom {

	// Interior
	public int width = 12;
	public int height = 10;

	public string levelText;

	public LevelObject[] levelObjects;
	public Vector2[] walls;

	//private void OnValidate() {
	//	int spawnCount = 0;
	//	int endCount = 0;
	//	for (int i = 0; i < levelObjects.Length; i++) {
	//		levelObjects[i].x = Mathf.Clamp(levelObjects[i].x, 1, width);
	//		levelObjects[i].y = Mathf.Clamp(levelObjects[i].y, 1, height);

	//		if (levelObjects[i].levelObjectType == LevelObjectType.Spawn) {
	//			spawnCount++;
	//		}
	//		if (levelObjects[i].levelObjectType == LevelObjectType.LevelEnd || levelObjects[i].hasLevelEnd) {
	//			endCount++;
	//		}
	//	}
	//	for (int i = 0; i < walls.Length; i++) {
	//		walls[i].x = Mathf.Clamp(walls[i].x, 1, width);
	//		walls[i].y = Mathf.Clamp(walls[i].y, 1, height);
	//	}



	//	if (spawnCount > 1) {
	//		Debug.LogError("Level can only contain one spawn point.");
	//	}
	//	if (spawnCount < 1) {
	//		Debug.LogWarning("Level must have one spawn point");
	//	}
	//	if (endCount < 1) {
	//		Debug.LogWarning("Level must have one end point");
	//	}
	//}

}
