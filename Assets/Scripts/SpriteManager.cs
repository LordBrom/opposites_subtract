using UnityEngine;

public class SpriteManager : MonoBehaviour {

	#region Inspector Assignments

	public ObjectPair[] objectPairs;

	#endregion

	public Sprite GetSprite(string objectName) {
		foreach (ObjectPair objectPair in objectPairs) {
			if (objectPair.name == objectName) {
				return objectPair.sprite;
			}
		}
		return null;
	}
}
