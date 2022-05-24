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
		this.HideMenu();
	}
	protected virtual void Update() {
	}
	#endregion

	public void ShowMenu() {
		this.showing = true;
		this.canvasGroup.alpha = 1;
		this.canvasGroup.interactable = true;
		this.canvasGroup.blocksRaycasts = true;
	}
	public void HideMenu() {
		this.showing = false;
		this.canvasGroup.alpha = 0;
		this.canvasGroup.interactable = false;
		this.canvasGroup.blocksRaycasts = false;
	}

	public virtual void ToggleMenu() {
		if (this.showing) {
			this.HideMenu();
		} else {
			this.ShowMenu();
		}
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene(0);
	}
}
