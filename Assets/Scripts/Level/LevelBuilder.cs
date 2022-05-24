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

	public GameObject displayTilePrefab;

	#endregion
	#region Variables

	protected List<GameObject> renderedLevelObjects = new List<GameObject>();
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
		if (buildMode) {
			SetDisplayTiles(level.spawn, level.levelObjects);
		} else {
			FillLevelObjects(level.levelObjects);
			SpawnPlayer(level.spawn);
			levelText.text = level.levelText;
		}
		SetCameraPosition(level.height, level.width);
	}

	public void AddLevelEnd(Vector2 pos) {
		renderedLevelObjects.Add(Instantiate(endPointPrefab, pos, Quaternion.identity, transform));
	}

	protected virtual void CreateBoarder(int height, int width) {
		GameObject newFloor = Instantiate(floorPrefab, transform);
		newFloor.transform.position = new Vector3((((float)width + 1) / 2) - 1, (((float)height + 1) / 2) - 1, 5);
		newFloor.transform.localScale = new Vector3((float)width + 2, (float)height + 2, 1);
		renderedLevelObjects.Add(newFloor);

		for (int x = 0; x <= width + 1; x++) {
			renderedLevelObjects.Add(Instantiate(wallPrefab, new Vector3(x - 1, -1, 3), Quaternion.identity, transform));
			renderedLevelObjects.Add(Instantiate(wallPrefab, new Vector3(x - 1, height, 3), Quaternion.identity, transform));
		}
		for (int y = 1; y <= height; y++) {
			renderedLevelObjects.Add(Instantiate(wallPrefab, new Vector3(-1, y - 1, 3), Quaternion.identity, transform));
			renderedLevelObjects.Add(Instantiate(wallPrefab, new Vector3(width, y - 1, 3), Quaternion.identity, transform));
		}
	}

	protected virtual void FillWalls(List<Vector2> walls) {
		if (walls == null) {
			return;
		}
		foreach (Vector2 wall in walls) {
			renderedLevelObjects.Add(Instantiate(wallPrefab, new Vector3(wall.x, wall.y, 1), Quaternion.identity, transform));
		}
	}

	protected virtual void FillLevelObjects(List<LevelObject> levelObjects) {
		if (levelObjects == null) {
			return;
		}
		foreach (LevelObject levelObject in levelObjects) {
			switch (levelObject.levelObjectType) {

				case LevelObjectType.LevelEnd:
					renderedLevelObjects.Add(Instantiate(endPointPrefab, levelObject.position, Quaternion.identity, transform));
					break;

				case LevelObjectType.Object:
					GameObject newObject = Instantiate(blockPrefab, new Vector3(levelObject.position.x, levelObject.position.y, 4), Quaternion.identity, transform);
					newObject.GetComponent<Reactor>().setBlockData(levelObject);
					renderedLevelObjects.Add(newObject);
					break;

				case LevelObjectType.DeathTile:
					renderedLevelObjects.Add(Instantiate(spikePrefab, levelObject.position, Quaternion.identity, transform));
					break;

				case LevelObjectType.InverseSpawn:
					renderedLevelObjects.Add(Instantiate(inversePlayerPrefab, new Vector3(levelObject.position.x, levelObject.position.y, 4), Quaternion.identity, transform));
					break;

				case LevelObjectType.FakeWall:
					renderedLevelObjects.Add(Instantiate(fakeWallPrefab, new Vector3(levelObject.position.x, levelObject.position.y, 3), Quaternion.identity, transform));
					break;

				default:
					break;
			}
		}
	}

	protected virtual void SpawnPlayer(Vector2 spawn) {
		renderedLevelObjects.Add(Instantiate(playerPrefab, new Vector3(spawn.x, spawn.y, 4), Quaternion.identity, this.transform));
	}

	protected virtual void SetCameraPosition(int height, int width) {
		cam.transform.position = new Vector3((((float)width + 1) / 2) - 1, (((float)height + 1) / 2) - 1, -10);


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
		foreach (GameObject levelObject in renderedLevelObjects) {
			Destroy(levelObject);
		}

		renderedLevelObjects.Clear();
	}

	protected virtual void SetDisplayTiles(Vector2 spawn, List<LevelObject> levelObjects) {
		renderedLevelObjects.Add(Instantiate(displayTilePrefab, new Vector3(spawn.x, spawn.y, 4), Quaternion.identity, this.transform));

		foreach (LevelObject levelObject in levelObjects) {
			renderedLevelObjects.Add(Instantiate(displayTilePrefab, new Vector3(levelObject.position.x, levelObject.position.y, 4), Quaternion.identity, this.transform));
		}
	}
}
