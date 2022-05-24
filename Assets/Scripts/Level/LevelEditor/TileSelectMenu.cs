using UnityEngine;

public class TileSelectMenu : HideableMenu {

	#region Inspector Assignments

	[SerializeField]
	private Transform tileOptionsTransform;
	[SerializeField]
	private ObjectPair[] objectPairs;
	[SerializeField]
	private GameObject tileOptionPrefab;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	protected override void Start() {
		//base().Start();
		//

		foreach (ObjectPair objectPair in this.objectPairs) {
			TileOption newOption = Instantiate(tileOptionPrefab, tileOptionsTransform).GetComponent<TileOption>();
			newOption.objectPair = objectPair;
		}

	}
	#endregion
}
