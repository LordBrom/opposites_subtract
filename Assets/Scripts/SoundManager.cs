using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource backgroundMusic;
	public AudioSource levelWin;
	public AudioSource levelLoose;

	public float masterVolume = 1.0f;
	public float musicVolume = 1.0f;
	public float effectVolume = 1.0f;

	private void Update() {
		masterVolume = Mathf.Clamp(masterVolume, 0f, 1f);
		musicVolume = Mathf.Clamp(musicVolume, 0f, 1f);
		effectVolume = Mathf.Clamp(effectVolume, 0f, 1f);

		levelWin.volume = GetEffectVolume();
		levelLoose.volume = GetEffectVolume();
		backgroundMusic.volume = GetMusicVolume();

	}

	public void PlayLevelWin() {
		levelWin.Play();
	}

	public void PlayLevelLoose() {
		levelLoose.Play();
		float fromSeconds = 0;
		float toSeconds = 0.5f;

		levelLoose.time = fromSeconds;
		levelLoose.Play();
		levelLoose.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}

	public float GetEffectVolume() {
		return (masterVolume * effectVolume);
	}
	public float GetMusicVolume() {
		return (masterVolume * musicVolume);
	}
}
