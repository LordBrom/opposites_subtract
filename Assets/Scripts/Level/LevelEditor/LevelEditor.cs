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
		this.level = new Level(true);

		this.widthInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.heightInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.levelTextInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.levelNameInput.onValueChanged.AddListener(delegate { UpdateLevel(); });

		this.widthInput.text = this.level.width.ToString();
		this.heightInput.text = this.level.height.ToString();
		this.levelTextInput.text = this.level.levelText;

		this.grid = new Grid(this.level.width, this.level.height, new Vector3(-0.5f, -0.5f));
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
							this.level.spawn = new Vector2(x, y);
							clickedTile.hasOther = true;
						}
						break;

					case LevelObject.Type.wall:
						if (!clickedTile.hasOther) {
							this.level.ToggleWall(new Vector2(x, y));
							clickedTile.hasWall = true;
						}
						break;

					case LevelObject.Type.LevelEnd:
					case LevelObject.Type.DeathTile:
					case LevelObject.Type.InverseSpawn:
					case LevelObject.Type.FakeWall:
						if (!clickedTile.hasWall) {
							LevelObject newObject = new LevelObject(this.activeTileType, new Vector2(x, y));
							this.level.levelObjects.Add(newObject);
							clickedTile.hasOther = true;
						}
						break;

					case LevelObject.Type.Object:
						if (!clickedTile.hasWall) {
							LevelObject newObjectPair = new LevelObject(this.activeTileType, new Vector2(x, y), this.activeObjectPair, this.GetNewCollisionId());
							this.level.levelObjects.Add(newObjectPair);
							clickedTile.hasOther = true;
						}
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

	public void UpdateLevel() {
		if (this.widthInput.text == "" || this.heightInput.text == "") {
			return;
		}
		this.level.width = int.Parse(this.widthInput.text);
		this.level.height = int.Parse(this.heightInput.text);
		this.level.levelText = this.levelTextInput.text;
		this.level.name = this.levelNameInput.text;
		BuildLevel(this.level, true);
	}

	public void SaveLevelButton() {
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
}
