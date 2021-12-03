using UnityEngine;

public class Mover : MonoBehaviour {

	#region Inspector Assignments

	public float speed = 1.0f;


	#endregion
	#region Variables

	protected BoxCollider2D boxCollider2D;
	protected RaycastHit2D hit;
	private Vector2 moveDelta;

	#endregion
	#region Unity Methods

	protected virtual void Start() {
		boxCollider2D = GetComponent<BoxCollider2D>();
	}

	#endregion

	protected virtual void updateMotor(Vector2 input) {
		moveDelta = new Vector2(input.x * speed, input.y * speed);

		// Rotate
		bool movedY = false;
		if (moveDelta.y != 0) {
			hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
			if (hit.collider == null) {
				transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
				movedY = true;
			}
		}

		if (!movedY && moveDelta.x != 0) {
			hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
			if (hit.collider == null) {
				transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
			}
		}
	}
}
