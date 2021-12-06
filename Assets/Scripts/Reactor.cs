using UnityEngine;

public class Reactor : Collidable {

	#region Inspector Assignments

	public ObjectPair objectPair;

	#endregion
	#region Variables

	public bool hasLevelEnd;

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
				if (hasLevelEnd) {
					GameManager.instance.levelBuilder.addLevelEnd(transform.position);
				} else if (otherReactor.hasLevelEnd) {
					GameManager.instance.levelBuilder.addLevelEnd(otherReactor.transform.position);
				}
				Destroy(gameObject);
				Destroy(coll.gameObject);
			}
		}
	}

	public virtual void setBlockData(ObjectPair blockData, bool _hasLevelEnd = false) {
		objectPair = blockData;
		name = blockData.name;
		hasLevelEnd = _hasLevelEnd;
		gameObject.GetComponent<SpriteRenderer>().sprite = blockData.sprite;
	}
}
