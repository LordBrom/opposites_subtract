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

		levelWin.volume = getEffectVolume();
		levelLoose.volume = getEffectVolume();
		backgroundMusic.volume = getMusicVolume();

	}

	public void playLevelWin() {
		levelWin.Play();
	}

	public void playLevelLoose() {
		levelLoose.Play();
		float fromSeconds = 0;
		float toSeconds = 0.5f;

		levelLoose.time = fromSeconds;
		levelLoose.Play();
		levelLoose.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
	}

	public float getEffectVolume() {
		return (masterVolume * effectVolume);
	}
	public float getMusicVolume() {
		return (masterVolume * musicVolume);
	}
}
