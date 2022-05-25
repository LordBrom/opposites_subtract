using UnityEngine;
using UnityEngine.UI;

public class TileOption : MonoBehaviour {

	#region Inspector Assignments

	[SerializeField]
	private LevelObject.Type objectType;
	[SerializeField]
	private Image isActiveIndicator;

	#endregion
	#region Variables

	public ObjectPair objectPair;
	private Image image;



	#endregion

	#region Unity Methods
	private void Start() {
		this.image = GetComponent<Image>();
		if (this.objectPair != null) {
			image.sprite = this.objectPair.sprite;
		}
	}

	private void Update() {
		if (LevelEditor.instance.hasActiveTile && LevelEditor.instance.activeTileType == this.objectType && LevelEditor.instance.activeObjectPair == this.objectPair) {
			this.isActiveIndicator.color = new Color(255, 255, 255, 1);
		} else {
			this.isActiveIndicator.color = new Color(255, 255, 255, 0);
		}
	}
	#endregion

	public void SetActiveTileButton() {
		LevelEditor.instance.SetActiveTileType(this.objectType, objectPair);
	}
}
