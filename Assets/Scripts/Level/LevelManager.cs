using UnityEngine;

public static class LevelManager {

	#region Inspector Assignments

	public static Level[] levels;
	public static Level activeLevel;

	#endregion
	#region Variables

	private static int currentLevel = -1;

	#endregion

	public static Level GetNextLevel() {
		currentLevel++;
		if (currentLevel < levels.Length) {
			return levels[currentLevel];
		}
		return null;
	}
}
