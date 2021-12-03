using UnityEngine;

public class Reactor : Collidable {

	#region Inspector Assignments

	public ObjectPair objectPair;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods

	private void OnValidate() {
		if (objectPair != null) {
			setBlockData(ScriptableObject.Instantiate(objectPair));
		}
	}

	#endregion

	protected override void onCollide(Collider2D coll) {
		Reactor otherReactor = coll.gameObject.GetComponent<Reactor>();

		if (otherReactor != null) {
			if (objectPair.reactsWithList().Contains(otherReactor.objectPair)) {
				Destroy(gameObject);
				Destroy(coll.gameObject);
			}
		}
	}

	protected virtual void setBlockData(ObjectPair blockData) {
		name = blockData.name;
		gameObject.GetComponent<SpriteRenderer>().sprite = blockData.sprite;
	}
}
