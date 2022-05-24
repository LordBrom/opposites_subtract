using UnityEngine;

public class InversePlayerController : PlayerController {

	protected override void FixedUpdate() {
		if (this.canMove) {
			float x = Input.GetAxisRaw("Horizontal");
			float y = Input.GetAxisRaw("Vertical");

			if (LevelPlayer.instance.levelActive) {
				UpdateMotor(new Vector2(-x, -y));
			}
		}
	}
}
