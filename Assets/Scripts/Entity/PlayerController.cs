using UnityEngine;

public class PlayerController : Mover {

	#region Inspector Assignments

	#endregion
	#region Variables

	public bool canMove = true;

	#endregion
	#region Unity Methods

	protected virtual void FixedUpdate() {
		if (this.canMove) {
			float x = Input.GetAxisRaw("Horizontal");
			float y = Input.GetAxisRaw("Vertical");

			if (LevelPlayer.instance.levelActive) {
				UpdateMotor(new Vector2(x, y));
			}
		}
	}

	#endregion
}
