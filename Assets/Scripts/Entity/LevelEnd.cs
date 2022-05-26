using UnityEngine;

public class LevelEnd : Collidable {
	#region Unity Methods

	protected override void OnCollide(Collider2D coll) {
		if (coll.CompareTag("Player")) {
			LevelPlayer.instance.EndLevel();
		}
	}
	#endregion
}
