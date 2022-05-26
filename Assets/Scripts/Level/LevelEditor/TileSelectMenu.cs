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

	protected override void Update() {
		base.Update();
		if (this.showing && LevelEditor.instance.hasActiveTile) {
			this.HideMenu();
		} else if (!this.showing && !LevelEditor.instance.hasActiveTile) {
			this.ShowMenu();
		}
	}
	#endregion
}
