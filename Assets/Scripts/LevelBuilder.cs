using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	#region Inspector Assignments

	public GameObject wallPrefab;
	public GameObject playerPrefab;
	public GameObject blockPrefab;

	#endregion
	#region Variables

	private List<GameObject> levelObjects = new List<GameObject>();

	#endregion



	public void buildLevel(Level level) {
		clearLevel();

		createBoarder(level.height, level.width);
		fillLevelObjects(level.levelObjects);
	}

	private void createBoarder(int width, int height) {
		for (int x = 0; x <= height + 1; x++) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector2(x, 0), Quaternion.identity, transform));
			levelObjects.Add(Instantiate(wallPrefab, new Vector2(x, width + 1), Quaternion.identity, transform));
		}
		for (int y = 1; y <= width; y++) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector2(0, y), Quaternion.identity, transform));
			levelObjects.Add(Instantiate(wallPrefab, new Vector2(height + 1, y), Quaternion.identity, transform));
		}
	}

	private void fillLevelObjects(LevelObject[] _levelObjects) {
		foreach (LevelObject levelObject in _levelObjects) {
			switch (levelObject.levelObjectType) {
				case LevelObjectType.Wall:
					levelObjects.Add(Instantiate(wallPrefab, new Vector2(levelObject.x, levelObject.y), Quaternion.identity, transform));
					break;

				case LevelObjectType.Spawn:
					levelObjects.Add(Instantiate(playerPrefab, new Vector2(levelObject.x, levelObject.y), Quaternion.identity, transform));
					break;

				case LevelObjectType.Object:
					GameObject newObject = Instantiate(blockPrefab, new Vector2(levelObject.x, levelObject.y), Quaternion.identity, transform);
					newObject.GetComponent<Reactor>().setBlockData(levelObject.objectPair);
					levelObjects.Add(newObject);
					break;

				default:
					break;
			}
		}
	}

	private void clearLevel() {
		foreach (GameObject levelObject in levelObjects) {
			Destroy(levelObject);
		}

		levelObjects.Clear();

	}

}
