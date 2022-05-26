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
		//parentHover.OnPointerEnter(eventData);
	}

	public void OnPointerExit(PointerEventData eventData) {
		//parentHover.OnPointerExit(eventData);
	}
	#endregion
}
