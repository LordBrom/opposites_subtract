using UnityEngine;
using UnityEngine.UI;

public class CollisionGroupNumIndicator : MonoBehaviour {

	#region Inspector Assignments

	[SerializeField]
	private Reactor parentTile;


	#endregion
	#region Variables

	private bool isHovering;
	private int groupCount = 10;
	private TextMesh collisionGroupText;

	#endregion

	#region Unity Methods
	void Awake() {
		gameObject.GetComponentInChildren<MeshRenderer>().sortingLayerName = "Default";
		gameObject.GetComponentInChildren<MeshRenderer>().sortingOrder = 3;
		collisionGroupText = gameObject.GetComponentInChildren<TextMesh>();
	}

	private void Update() {
		if (this.isHovering && Input.GetMouseButtonDown(0)) {
			parentTile.SetCollisionGroupNum(1);
		} else if (this.isHovering && Input.GetMouseButtonDown(1)) {
			parentTile.SetCollisionGroupNum(-1);
		}
		collisionGroupText.text = parentTile.collisionGroupNum.ToString();
	}

	public void OnMouseEnter() {
		this.isHovering = true;
	}
	public void OnMouseExit() {
		this.isHovering = false;
	}
	#endregion
}
