using UnityEngine;
using UnityEngine.SceneManagement;

public class HideableMenu : MonoBehaviour {

	#region Variables

	private CanvasGroup canvasGroup;
	protected bool showing;

	#endregion

	#region Unity Methods
	void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();
	}

	protected virtual void Start() {
		HideMenu();
	}
	#endregion

	public void ShowMenu() {
		showing = true;
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}
	public void HideMenu() {
		showing = false;
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	public virtual void ToggleMenu() {
		if (showing) {
			HideMenu();
		} else {
			ShowMenu();
		}
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene(0);
	}
}
