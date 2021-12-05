using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuilder : MonoBehaviour {

	#region Inspector Assignments

	public GameObject wallPrefab;
	public GameObject playerPrefab;
	public GameObject endPointPrefab;
	public GameObject blockPrefab;
	public GameObject floorPrefab;
	public Text levelText;

	#endregion
	#region Variables

	private List<GameObject> levelObjects = new List<GameObject>();
	private Camera cam;

	#endregion

	#region Unity Methods
	protected virtual void Start() {
		cam = Camera.main;
	}

	#endregion

	public void buildLevel(Level level) {
		clearLevel();

		createBoarder(level.height, level.width);
		fillLevelObjects(level.levelObjects);
		setCameraPosition(level.height, level.width);

		levelText.text = level.levelText;
	}

	private void createBoarder(int height, int width) {
		GameObject newFloor = Instantiate(floorPrefab, transform);
		newFloor.transform.position = new Vector3(((float)width + 1) / 2, ((float)height + 1) / 2, 2);
		newFloor.transform.localScale = new Vector3((float)width + 2, (float)height + 2, 1);
		levelObjects.Add(newFloor);

		for (int x = 0; x <= width + 1; x++) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(x, 0, 1), Quaternion.identity, transform));
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(x, height + 1, 1), Quaternion.identity, transform));
		}
		for (int y = 1; y <= height; y++) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(0, y, 1), Quaternion.identity, transform));
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(width + 1, y, 1), Quaternion.identity, transform));
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

				case LevelObjectType.LevelEnd:
					levelObjects.Add(Instantiate(endPointPrefab, new Vector2(levelObject.x, levelObject.y), Quaternion.identity, transform));
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

	private void setCameraPosition(int height, int width) {
		cam.transform.position = new Vector3(((float)width + 1) / 2, ((float)height + 1) / 2, -10);


		float unitsPerPixel;
		if (height > width) {
			unitsPerPixel = ((float)height + 2) / Screen.height;
		} else {
			unitsPerPixel = ((float)width + 2) / Screen.width;
		}
		float desiredScale = 0.5f * unitsPerPixel * Screen.height;
		cam.orthographicSize = desiredScale;
	}

	private void clearLevel() {
		foreach (GameObject levelObject in levelObjects) {
			Destroy(levelObject);
		}

		levelObjects.Clear();
	}

}
