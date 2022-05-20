using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : LevelBuilder {

	#region Inspector Assignments

	public InputField widthInput;
	public InputField heightInput;
	public InputField levelTextInput;
	public Level level;

	#endregion
	#region Variables

	private LevelSaveLoad levelSaveLoad = new LevelSaveLoad();

	#endregion

	#region Unity Methods
	private void Start() {
		widthInput.onValueChanged.AddListener(delegate { SaveLevel(); });
		heightInput.onValueChanged.AddListener(delegate { SaveLevel(); });
		levelTextInput.onValueChanged.AddListener(delegate { SaveLevel(); });


		//level.setFromCustom(levelSaveLoad.LoadLevelFromJson("new_level"));

		widthInput.text = level.width.ToString();
		heightInput.text = level.height.ToString();
		levelTextInput.text = level.levelText;

		BuildLevel();

	}
	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			BuildLevel();
		}
	}
	#endregion

	public void SaveLevel() {
		level.width = int.Parse(widthInput.text);
		level.height = int.Parse(heightInput.text);
		level.levelText = levelTextInput.text;
	}

	public void BuildLevel() {
		ClearLevel();

		int width = int.Parse(widthInput.text);
		int height = int.Parse(heightInput.text);

		CreateBoarder(height, width);
		FillLevelObjects(level.levelObjects);
		SetCameraPosition(height, width);

		//levelText.text = level.levelText;
	}
}
