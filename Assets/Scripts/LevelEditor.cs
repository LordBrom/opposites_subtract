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
		widthInput.onValueChanged.AddListener(delegate { saveLevel(); });
		heightInput.onValueChanged.AddListener(delegate { saveLevel(); });
		levelTextInput.onValueChanged.AddListener(delegate { saveLevel(); });


		level.setFromCustom(levelSaveLoad.LoadLevelFromJson("new_level"));

		widthInput.text = level.width.ToString();
		heightInput.text = level.height.ToString();
		levelTextInput.text = level.levelText;

		buildLevel();

	}
	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			buildLevel();
		}
	}
	#endregion

	public void saveLevel() {
		level.width = int.Parse(widthInput.text);
		level.height = int.Parse(heightInput.text);
		level.levelText = levelTextInput.text;
	}

	public void buildLevel() {
		clearLevel();

		int width = int.Parse(widthInput.text);
		int height = int.Parse(heightInput.text);

		createBoarder(height, width);
		fillLevelObjects(level.levelObjects);
		setCameraPosition(height, width);

		//levelText.text = level.levelText;
	}
}
