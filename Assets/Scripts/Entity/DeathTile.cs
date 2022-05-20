using UnityEngine;

public class DeathTile : Collidable {
	#region Unity Methods

	protected override void onCollide(Collider2D coll) {
		if (coll.CompareTag("Player") || coll.CompareTag("InvPlayer")) {
			GameManager.instance.showDeathMenu();
		}
	}
	#endregion
}
