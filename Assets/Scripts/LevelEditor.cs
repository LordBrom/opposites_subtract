using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : MonoBehaviour {

	#region Inspector Assignments

	public InputField widthInput;
	public InputField heightInput;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	void Start() {

		widthInput.onValueChanged.AddListener(delegate { createBoarder(); });
		heightInput.onValueChanged.AddListener(delegate { createBoarder(); });
	}

	void Update() {

	}
	#endregion

	private void createBoarder() {
		//for (int x = 0; x <= width + 1; x++) {
		//	levelObjects.Add(Instantiate(wallPrefab, new Vector2(x, 0), Quaternion.identity, transform));
		//	levelObjects.Add(Instantiate(wallPrefab, new Vector2(x, height + 1), Quaternion.identity, transform));
		//}
		//for (int y = 1; y <= height; y++) {
		//	levelObjects.Add(Instantiate(wallPrefab, new Vector2(0, y), Quaternion.identity, transform));
		//	levelObjects.Add(Instantiate(wallPrefab, new Vector2(width + 1, y), Quaternion.identity, transform));
		//}
	}
}
