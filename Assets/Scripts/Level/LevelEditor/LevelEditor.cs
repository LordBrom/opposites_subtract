using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : LevelBuilder {

	#region Singleton
	public static LevelEditor instance;

	protected override void Awake() {
		base.Awake();
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	#region Inspector Assignments

	public PauseMenu pauseMenu;

	public InputField widthInput;
	public InputField heightInput;
	public InputField levelTextInput;
	public InputField levelNameInput;
	public Level level;

	private Grid grid;

	#endregion
	#region Variables


	public bool hasActiveTile { get; private set; }
	public LevelObject.Type activeTileType { get; private set; }
	public ObjectPair activeObjectPair { get; private set; }

	#endregion

	#region Unity Methods
	private void Start() {
		this.level = LevelManager.level;
		if (this.level == null) {
			this.level = new Level(isCustom: true);
		}

		this.widthInput.text = this.level.width.ToString();
		this.heightInput.text = this.level.height.ToString();
		this.levelTextInput.text = this.level.levelText;
		this.levelNameInput.text = this.level.name;

		this.widthInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.heightInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.levelTextInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.levelNameInput.onValueChanged.AddListener(delegate { UpdateLevel(); });

		SetupNewGrid();
		BuildLevel(this.level, true);
	}
	void Update() {
		if (this.hasActiveTile && Input.GetMouseButtonDown(0) && this.grid.OnGrid()) {
			this.grid.GetXY(out int x, out int y);
			GridTile clickedTile = this.grid.GetGridTile(x, y);

			if (clickedTile != null) {
				switch (this.activeTileType) {

					case LevelObject.Type.Spawn:
						if (!clickedTile.hasWall && !clickedTile.hasOther) {
							this.grid.GetGridTile(this.level.spawn).hasOther = false;
							this.level.spawn = new Vector2(x, y);
							clickedTile.hasOther = true;
						}
						this.ClearActiveTileType();
						break;

					case LevelObject.Type.wall:
						if (!clickedTile.hasOther && !clickedTile.hasFakeWall) {
							clickedTile.hasWall = this.level.ToggleWall(new Vector2(x, y));
						}
						break;

					case LevelObject.Type.FakeWall:
						this.SetTileObject(clickedTile, isFakeWall: true);
						break;

					case LevelObject.Type.LevelEnd:
					case LevelObject.Type.DeathTile:
					case LevelObject.Type.InverseSpawn:
						this.SetTileObject(clickedTile);
						break;

					case LevelObject.Type.Object:
						this.SetTileObject(clickedTile, isObjectPair: true);
						break;

					default:
						break;
				}
				UpdateLevel();
			}
		} else if (this.hasActiveTile && Input.GetMouseButtonDown(1)) {
			this.ClearActiveTileType();
		}
	}
	#endregion

	private void SetTileObject(GridTile clickedTile, bool isFakeWall = false, bool isObjectPair = false) {
		if (clickedTile.hasWall) {
			return;
		}

		if (isFakeWall && clickedTile.hasFakeWall) {
			this.level.levelObjects.Remove(clickedTile.fakeWallObject);
			clickedTile.fakeWallObject = null;
			clickedTile.hasFakeWall = false;
			return;
		} else if (!isFakeWall && clickedTile.hasOther) {
			this.level.levelObjects.Remove(clickedTile.placedObject);
			if (clickedTile.placedObject.type == this.activeTileType) {
				if (this.activeObjectPair == null || this.activeObjectPair.name == clickedTile.placedObject.name) {
					clickedTile.placedObject = null;
					clickedTile.hasOther = false;
					return;
				}
			}
		}

		LevelObject newObject;
		if (isObjectPair) {
			newObject = new LevelObject(this.activeTileType, new Vector2(clickedTile.x, clickedTile.y), this.activeObjectPair, this.GetNewCollisionId());
		} else {
			newObject = new LevelObject(this.activeTileType, new Vector2(clickedTile.x, clickedTile.y));
		}
		this.level.levelObjects.Add(newObject);
		if (isFakeWall) {
			clickedTile.fakeWallObject = newObject;
			clickedTile.hasFakeWall = true;
		} else {
			clickedTile.placedObject = newObject;
			clickedTile.hasOther = true;
		}

		if (!Input.GetKey(KeyCode.LeftShift)) {
			this.ClearActiveTileType();
		}
	}

	public void UpdateLevel() {
		if (this.widthInput.text == "" || this.heightInput.text == "") {
			return;
		}
		bool resetGrid = false;
		int newWidth = int.Parse(this.widthInput.text);
		int newHeight = int.Parse(this.heightInput.text);
		if (this.level.width != newWidth || this.level.height != newHeight) {
			resetGrid = true;
		}
		this.level.width = newWidth;
		this.level.height = newHeight;
		this.level.levelText = this.levelTextInput.text;
		this.level.name = this.levelNameInput.text;
		if (resetGrid) {
			SetupNewGrid();
		}
		BuildLevel(this.level, true);
	}

	public void SaveLevelButton(bool asCustom = true) {
		this.level.isCustom = asCustom;
		LevelSaveLoad.SaveLevelJson(this.level);
	}

	public void SetActiveTileType(LevelObject.Type levelObjectType, ObjectPair objectPair) {
		this.activeTileType = levelObjectType;
		this.activeObjectPair = objectPair;
		hasActiveTile = true;
	}

	public void ClearActiveTileType() {
		this.hasActiveTile = false;
	}

	public string GetNewCollisionId() {
		return "super random string";
	}

	public void RemoveOutOfBounds() {
		List<Vector2> wallsToRemove = new List<Vector2>();
		foreach (Vector2 wall in this.level.walls) {
			if (!this.grid.OnGrid(wall.x, wall.y)) {
				wallsToRemove.Add(wall);
			}
		}
		foreach (Vector2 wall in wallsToRemove) {
			this.level.walls.Remove(wall);
		}
		List<LevelObject> objectsToRemove = new List<LevelObject>();
		foreach (LevelObject levelObject in this.level.levelObjects) {
			if (!this.grid.OnGrid(levelObject.position)) {
				objectsToRemove.Add(levelObject);
			}
		}
		foreach (LevelObject objs in objectsToRemove) {
			this.level.levelObjects.Remove(objs);
		}
	}

	public void SetupNewGrid() {
		this.grid = new Grid(this.level.width, this.level.height, new Vector3(-0.5f, -0.5f));
		RemoveOutOfBounds();
		GridTile gridTile;
		foreach (Vector2 wall in this.level.walls) {
			gridTile = this.grid.GetGridTile(wall.x, wall.y);
			if (gridTile != null) {
				gridTile.hasWall = true;
			}
		}
		foreach (LevelObject levelObject in this.level.levelObjects) {
			gridTile = this.grid.GetGridTile(levelObject.position.x, levelObject.position.y);

			if (gridTile != null) {
				gridTile.placedObject = levelObject;
				if (levelObject.type == LevelObject.Type.FakeWall) {
					gridTile.hasFakeWall = true;
					gridTile.fakeWallObject = levelObject;
				} else {
					gridTile.hasOther = true;
					gridTile.placedObject = levelObject;
				}
			}
		}
	}
}
