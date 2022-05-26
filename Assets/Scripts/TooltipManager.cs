using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour {

	#region Singleton

	public static TooltipManager instance;

	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}

	#endregion
	#region Inspector Assignments

	[SerializeField]
	private Text tooltipText;

	#endregion
	#region Variables

	private CanvasGroup canvasGroup;
	private RectTransform rectTransform;

	#endregion

	#region Unity Methods
	private void Start() {
		this.canvasGroup = GetComponent<CanvasGroup>();
		this.rectTransform = GetComponent<RectTransform>();
		HideTooltip();
	}

	private void Update() {
		SetTooltipPosition();
	}
	#endregion

	public void SetHoverTooltip(string tooltipText) {
		this.tooltipText.text = tooltipText;
		ShowTooltip();
	}

	public void ClearHoverTooltip() {
		HideTooltip();
	}


	private void ShowTooltip() {
		this.canvasGroup.alpha = 1;
	}

	private void HideTooltip() {
		this.canvasGroup.alpha = 0;
	}

	private void SetTooltipPosition() {
		SetPivot();
		transform.position = Input.mousePosition;
	}
	private void SetPivot() {
		int pivotX = 0;
		int pivotY = 0;

		if (Screen.width < Input.mousePosition.x + this.rectTransform.sizeDelta.x) {
			pivotX = 1;
		}
		if (Screen.height < Input.mousePosition.y + this.rectTransform.sizeDelta.y) {
			pivotY = 1;
		}

		this.rectTransform.pivot = new Vector2(pivotX, pivotY);
	}
}
