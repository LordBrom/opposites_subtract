using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuilder : MonoBehaviour {

	#region Inspector Assignments

	public GameObject wallPrefab;
	public GameObject playerPrefab;
	public GameObject inversePlayerPrefab;
	public GameObject endPointPrefab;
	public GameObject blockPrefab;
	public GameObject floorPrefab;
	public GameObject spikePrefab;
	public GameObject fakeWallPrefab;
	public Text levelText;

	#endregion
	#region Variables

	protected List<GameObject> levelObjects = new List<GameObject>();
	protected Camera cam;

	#endregion

	#region Unity Methods
	protected virtual void Awake() {
		cam = Camera.main;
	}

	#endregion

	public virtual void BuildLevel(Level level, bool buildMode = false) {
		ClearLevel();

		CreateBoarder(level.height, level.width);
		FillWalls(level.walls);
		FillLevelObjects(level.levelObjects);
		if (!buildMode) {
			SpawnPlayer(level.spawn);
		}
		SetCameraPosition(level.height, level.width);

		if (!buildMode) {
			levelText.text = level.levelText;
		}
	}

	public void AddLevelEnd(Vector2 pos) {
		levelObjects.Add(Instantiate(endPointPrefab, pos, Quaternion.identity, transform));
	}

	protected virtual void CreateBoarder(int height, int width) {
		GameObject newFloor = Instantiate(floorPrefab, transform);
		newFloor.transform.position = new Vector3(((float)width + 1) / 2, ((float)height + 1) / 2, 5);
		newFloor.transform.localScale = new Vector3((float)width + 2, (float)height + 2, 1);
		levelObjects.Add(newFloor);

		for (int x = 0; x <= width + 1; x++) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(x, 0, 3), Quaternion.identity, transform));
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(x, height + 1, 3), Quaternion.identity, transform));
		}
		for (int y = 1; y <= height; y++) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(0, y, 3), Quaternion.identity, transform));
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(width + 1, y, 3), Quaternion.identity, transform));
		}
	}

	protected virtual void FillWalls(List<Vector2> walls) {
		if (walls == null) {
			return;
		}
		foreach (Vector2 wall in walls) {
			levelObjects.Add(Instantiate(wallPrefab, new Vector3(wall.x, wall.y, 1), Quaternion.identity, transform));
		}
	}

	protected virtual void FillLevelObjects(LevelObject[] _levelObjects) {
		if (_levelObjects == null) {
			return;
		}
		foreach (LevelObject levelObject in _levelObjects) {
			switch (levelObject.levelObjectType) {

				case LevelObjectType.LevelEnd:
					levelObjects.Add(Instantiate(endPointPrefab, levelObject.position, Quaternion.identity, transform));
					break;

				case LevelObjectType.Object:
					GameObject newObject = Instantiate(blockPrefab, new Vector3(levelObject.position.x, levelObject.position.y, 4), Quaternion.identity, transform);
					newObject.GetComponent<Reactor>().setBlockData(levelObject);
					levelObjects.Add(newObject);
					break;

				case LevelObjectType.DeathTile:
					levelObjects.Add(Instantiate(spikePrefab, levelObject.position, Quaternion.identity, transform));
					break;

				case LevelObjectType.InverseSpawn:
					levelObjects.Add(Instantiate(inversePlayerPrefab, new Vector3(levelObject.position.x, levelObject.position.y, 4), Quaternion.identity, transform));
					break;

				case LevelObjectType.FakeWall:
					levelObjects.Add(Instantiate(fakeWallPrefab, new Vector3(levelObject.position.x, levelObject.position.y, 3), Quaternion.identity, transform));
					break;

				default:
					break;
			}
		}
	}

	protected virtual void SpawnPlayer(Vector2 spawn) {
		levelObjects.Add(Instantiate(playerPrefab, new Vector3(spawn.x, spawn.y, 4), Quaternion.identity, transform));
	}

	protected virtual void SetCameraPosition(int height, int width) {
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

	protected virtual void ClearLevel() {
		foreach (GameObject levelObject in levelObjects) {
			Destroy(levelObject);
		}

		levelObjects.Clear();
	}

}
