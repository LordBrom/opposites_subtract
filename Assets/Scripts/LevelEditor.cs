using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LevelEditor : LevelBuilder {

	#region Inspector Assignments


	public InputField widthInput;
	public InputField heightInput;

	#endregion
	#region Variables

	private Level level;

	#endregion

	#region Unity Methods
	protected override void Start() {
		widthInput.onValueChanged.AddListener(delegate { saveLevel(); });
		heightInput.onValueChanged.AddListener(delegate { saveLevel(); });
		level = new Level();
		base.Start();

		buildLevel();
	}
	#endregion

	public void saveLevel() {
		level.width = int.Parse(widthInput.text);
		level.height = int.Parse(heightInput.text);

		EditorUtility.SetDirty(level);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}

	public void buildLevel() {
		clearLevel();

		int width = int.Parse(widthInput.text);
		int height = int.Parse(heightInput.text);

		createBoarder(height, width);
		//fillLevelObjects(level.levelObjects);
		setCameraPosition(height, width);

		//levelText.text = level.levelText;
	}
}
