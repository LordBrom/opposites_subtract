using UnityEngine;

public class InversePlayerController : PlayerController {

	protected override void FixedUpdate() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		updateMotor(new Vector2(-x, -y));
	}
}
