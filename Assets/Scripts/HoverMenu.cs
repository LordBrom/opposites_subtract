using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	#region Inspector Assignments

	public float hiddenAlpha = 1f;

	#endregion
	#region Variables

	private CanvasGroup canvasGroup;

	#endregion

	#region Unity Methods
	private void Start() {
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = hiddenAlpha;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		canvasGroup.alpha = 1f;
	}

	public void OnPointerExit(PointerEventData eventData) {
		canvasGroup.alpha = hiddenAlpha;
	}
	#endregion
}
