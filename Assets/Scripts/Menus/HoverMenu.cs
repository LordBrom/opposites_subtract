using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	#region Inspector Assignments

	public float hiddenAlpha = 1f;

	#endregion
	#region Variables

	private CanvasGroup canvasGroup;
	private int counter;

	#endregion

	#region Unity Methods
	private void Start() {
		this.canvasGroup = GetComponent<CanvasGroup>();
		this.canvasGroup.alpha = hiddenAlpha;
	}

	private void Update() {
		if (this.counter > 0) {
			this.canvasGroup.alpha = 1f;
		} else {
			this.canvasGroup.alpha = hiddenAlpha;
		}
	}

	public void OnPointerEnter(PointerEventData eventData) {
		this.counter += 1;
		//Debug.Log("Entered " + this.name + " " + this.counter.ToString());
		//canvasGroup.alpha = 1f;
	}

	public void OnPointerExit(PointerEventData eventData) {
		this.counter -= 1;
		if (this.counter < 0) {
			this.counter = 0;
		}
		//Debug.Log("Exit " + this.name + " " + this.counter.ToString());
		//canvasGroup.alpha = hiddenAlpha;
	}
	#endregion
}
