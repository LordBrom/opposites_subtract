using UnityEngine;

public class SoundManager : MonoBehaviour {

	#region Singleton
	public static SoundManager instance;

	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	public AudioSource backgroundMusic;
	public AudioSource levelWin;
	public AudioSource LevelLose;

	public float masterVolume = 1.0f;
	public float musicVolume = 1.0f;
	public float effectVolume = 1.0f;

	private void Update() {
		masterVolume = Mathf.Clamp(masterVolume, 0f, 1f);
		musicVolume = Mathf.Clamp(musicVolume, 0f, 1f);
		effectVolume = Mathf.Clamp(effectVolume, 0f, 1f);

		levelWin.volume = GetEffectVolume();
		LevelLose.volume = GetEffectVolume();
		backgroundMusic.volume = GetMusicVolume();

	}

	public void PlayLevelWin() {
		levelWin.Play();
	}

	public void PlayLevelLose() {
		LevelLose.Play();
		float fromSeconds = 0;
		float toSeconds = 0.5f;

		LevelLose.time = fromSeconds;
		LevelLose.Play();
		LevelLose.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}

	public float GetEffectVolume() {
		return (masterVolume * effectVolume);
	}
	public float GetMusicVolume() {
		return (masterVolume * musicVolume);
	}
}
