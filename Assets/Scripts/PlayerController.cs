using UnityEngine;

public class PlayerController : Mover {

	#region Inspector Assignments

	#endregion
	#region Variables

	#endregion
	#region Unity Methods

	private void FixedUpdate() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		updateMotor(new Vector2(x, y));
	}
	public void onSceneLoad() {
		transform.position = GameObject.Find("SpawnPoint").transform.position;
	}

	#endregion
}
