using UnityEngine;

public class DeathTile : Collidable {
	#region Unity Methods

	protected override void OnCollide(Collider2D coll) {
		if (coll.CompareTag("Player") || coll.CompareTag("InvPlayer")) {
			GameManager.instance.ShowDeathMenu();
		}
	}
	#endregion
}
