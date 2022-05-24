using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelListItem : MonoBehaviour {

	#region Inspector Assignments

	[SerializeField]
	private Text levelName;
	[SerializeField]
	private Text levelText;

	#endregion
	#region Variables

	private Level level;

	#endregion

	public void SetLevelData(Level level, bool asEdit = false) {
		this.level = level;
		this.levelName.text = level.name;
		this.levelText.text = level.levelText;
	}

	public void SelectLevel() {
		LevelManager.SetLevel(this.level);
		SceneManager.LoadScene(1);
	}
}
