using UnityEngine;

public class GameManager : MonoBehaviour {

	#region Singleton
	public static GameManager instance;

	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	#region Inspector Assignments

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	#endregion

	public void StartGame() {
	}

}
