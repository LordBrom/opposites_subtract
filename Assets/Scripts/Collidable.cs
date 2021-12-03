using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour {

	#region Inspector Assignments

	public ContactFilter2D filter;

	#endregion
	#region Variables

	private BoxCollider2D boxCollider2D;
	private List<Collider2D> hits = new List<Collider2D>();

	#endregion

	#region Unity Methods
	protected virtual void Start() {
		boxCollider2D = GetComponent<BoxCollider2D>();
	}

	void Update() {
		boxCollider2D.OverlapCollider(filter, hits);

		foreach (Collider2D hit in hits) {
			onCollide(hit);
		}
	}
	#endregion

	protected virtual void onCollide(Collider2D coll) {
		Debug.LogWarning("onCollide not implemented for " + this.name + ". Hitting " + coll.name);
	}
}
