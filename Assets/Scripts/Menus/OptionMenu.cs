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
		GameManager.instance.soundManager.masterVolume = masterVolumeSlider.value;
		SaveVolume();
	}

	private void SetMusicVolume() {
		GameManager.instance.soundManager.musicVolume = musicVolumeSlider.value;
		SaveVolume();
	}

	private void SetEffectVolume() {
		GameManager.instance.soundManager.effectVolume = effectVolumeSlider.value;
		SaveVolume();
	}

	private void SaveVolume() {
		string data = "";
		data += GameManager.instance.soundManager.masterVolume.ToString() + "|";
		data += GameManager.instance.soundManager.musicVolume.ToString() + "|";
		data += GameManager.instance.soundManager.effectVolume.ToString();

		PlayerPrefs.SetString(saveStr, data);
	}


}
