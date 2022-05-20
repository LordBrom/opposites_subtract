using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : LevelBuilder {

	#region Inspector Assignments

	public InputField widthInput;
	public InputField heightInput;
	public InputField levelTextInput;
	public Level level;

	private Grid grid;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	private void Start() {
		this.level = new Level();

		this.widthInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.heightInput.onValueChanged.AddListener(delegate { UpdateLevel(); });
		this.levelTextInput.onValueChanged.AddListener(delegate { UpdateLevel(); });

		this.widthInput.text = this.level.width.ToString();
		this.heightInput.text = this.level.height.ToString();
		this.levelTextInput.text = this.level.levelText;

		BuildLevel(this.level, true);

	}
	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			BuildLevel(this.level);
		}

		if (Input.GetMouseButtonDown(0) && this.grid.OnGrid()) {
			this.grid.GetXY(out int x, out int y);
			Debug.Log(Input.mousePosition + " " + x + " " + y);

			this.level.AddWall(new Vector2(x, y));
			UpdateLevel();

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
		this.grid = new Grid(this.level.width, this.level.height, true);
		BuildLevel(this.level, true);
	}

	public void SaveLevelButton() {
		LevelSaveLoad.SaveLevelJson(this.level, "testLevel");
	}
}
