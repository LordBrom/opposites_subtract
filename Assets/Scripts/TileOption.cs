using UnityEngine;
using UnityEngine.UI;

public class TileOption : MonoBehaviour {

	#region Inspector Assignments

	[SerializeField]
	private LevelObjectType objectType;

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

	}
	#endregion

	public void SetActiveTileButton() {
		LevelEditor.instance.SetActiveTileType(this.objectType, objectPair);
	}
}
