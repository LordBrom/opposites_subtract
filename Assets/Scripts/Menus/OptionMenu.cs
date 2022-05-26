using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : HideableMenu {

	public Slider masterVolumeSlider;
	public Slider musicVolumeSlider;
	public Slider effectVolumeSlider;

	private string saveStr = "soundVolume";

	protected override void Start() {
		masterVolumeSlider.onValueChanged.AddListener(delegate { SetMasterVolume(); });
		musicVolumeSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
		effectVolumeSlider.onValueChanged.AddListener(delegate { SetEffectVolume(); });

		if (!PlayerPrefs.HasKey(saveStr)) {
			PlayerPrefs.SetString(saveStr, "1|1|1");
		}

		string[] data = PlayerPrefs.GetString(saveStr).Split('|');

		masterVolumeSlider.value = float.Parse(data[0]);
		musicVolumeSlider.value = float.Parse(data[1]);
		effectVolumeSlider.value = float.Parse(data[2]);

		SetMasterVolume();
		SetMusicVolume();
		SetEffectVolume();

		base.Start();
	}

	private void SetMasterVolume() {
		SoundManager.instance.masterVolume = masterVolumeSlider.value;
		SaveVolume();
	}

	private void SetMusicVolume() {
		SoundManager.instance.musicVolume = musicVolumeSlider.value;
		SaveVolume();
	}

	private void SetEffectVolume() {
		SoundManager.instance.effectVolume = effectVolumeSlider.value;
		SaveVolume();
	}

	private void SaveVolume() {
		string data = "";
		data += SoundManager.instance.masterVolume.ToString() + "|";
		data += SoundManager.instance.musicVolume.ToString() + "|";
		data += SoundManager.instance.effectVolume.ToString();

		PlayerPrefs.SetString(saveStr, data);
	}


}
