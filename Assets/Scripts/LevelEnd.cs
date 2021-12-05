using UnityEngine;

public class LevelEnd : Collidable {
	#region Unity Methods

	protected override void onCollide(Collider2D coll) {
		if (coll.CompareTag("Player")) {
			GameManager.instance.endLevel();
		}
	}
	#endregion
}
