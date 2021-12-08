using UnityEngine;

public class HideableMenu : MonoBehaviour {

	#region Variables

	private CanvasGroup canvasGroup;
	private bool showing;

	#endregion

	#region Unity Methods
	void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();
	}

	protected virtual void Start() {
		hideMenu();
	}
	#endregion

	public void showMenu() {
		showing = true;
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}
	public void hideMenu() {
		showing = false;
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	public virtual void toggleMenu() {
		if (showing) {
			hideMenu();
		} else {
			showMenu();
		}
	}
}
