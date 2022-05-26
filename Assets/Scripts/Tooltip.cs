using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	#region Inspector Assignments

	public string tooltipText;

	#endregion

	public void OnPointerEnter(PointerEventData eventData) {
		TooltipManager.instance.SetHoverTooltip(tooltipText);
	}

	public void OnPointerExit(PointerEventData eventData) {
		TooltipManager.instance.ClearHoverTooltip();
	}
}
