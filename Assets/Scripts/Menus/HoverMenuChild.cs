using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenuChild : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	#region Inspector Assignments

	[SerializeField]
	private HoverMenu parentHover;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	private void Start() {

	}

	private void Update() {

	}

	public void OnPointerEnter(PointerEventData eventData) {
		Debug.Log("Entered " + this.name);
		parentHover.OnPointerEnter(eventData);
	}

	public void OnPointerExit(PointerEventData eventData) {
		Debug.Log("Exit " + this.name);
		parentHover.OnPointerExit(eventData);
	}
	#endregion
}
