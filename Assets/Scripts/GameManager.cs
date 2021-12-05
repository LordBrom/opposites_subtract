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

	public LevelBuilder levelBuilder;
	public Level testLevel;

	#endregion
	#region Variables

	#endregion

	#region Unity Methods
	void Start() {
		levelBuilder.buildLevel(testLevel);
	}

	void Update() {

	}
	#endregion
}
