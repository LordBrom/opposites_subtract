using UnityEngine;

public class LevelManager : MonoBehaviour {

	#region Inspector Assignments

	public Level[] levels;

	#endregion
	#region Variables

	private int currentLevel = -1;

	#endregion

	public Level GetNextLevel() {
		currentLevel++;
		if (currentLevel < levels.Length) {
			return levels[currentLevel];
		}
		return null;
	}
}
