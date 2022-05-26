using UnityEngine;

public class LevelEndIndicator : MonoBehaviour {

	#region Inspector Assignments

	[SerializeField]
	private Reactor parentTile;
	public Color activeColor;
	public Color inactiveColor;


	#endregion
	#region Variables

	private bool isHovering;
	private SpriteRenderer spriteRenderer;

	#endregion

	#region Unity Methods
	private void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		if (parentTile.hasLevelEnd) {
			this.spriteRenderer.color = activeColor;
		} else {
			this.spriteRenderer.color = inactiveColor;
		}
		if (this.isHovering && Input.GetMouseButtonDown(0)) {
			this.parentTile.ToggleHasLevelEnd();
		}
	}

	public void OnMouseEnter() {
		this.isHovering = true;
	}
	public void OnMouseExit() {
		this.isHovering = false;
	}
	#endregion
}
