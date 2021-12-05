using UnityEngine;

public class LevelOverMenu : MonoBehaviour {

	#region Inspector Assignments

	#endregion
	#region Variables

	private CanvasGroup canvasGroup;

	#endregion

	#region Unity Methods
	void Start() {
		canvasGroup = GetComponent<CanvasGroup>();
	}

	void Update() {

	}
	#endregion

	public void showMenu() {
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}
	public void hideMenu() {
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}
}
