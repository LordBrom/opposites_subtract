using UnityEngine;

public class PlayerController : Mover {

	#region Inspector Assignments

	#endregion
	#region Variables

	#endregion
	#region Unity Methods

	protected virtual void FixedUpdate() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		if (LevelPlayer.instance.levelActive) {
			UpdateMotor(new Vector2(x, y));
		}
	}

	#endregion
}
