using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : HideableMenu {

	public Slider masterVolumeSlider;
	public Slider musicVolumeSlider;
	public Slider effectVolumeSlider;

	private string saveStr = "soundVolume";

	protected override void Start() {
		masterVolumeSlider.onValueChanged.AddListener(delegate { setMasterVolume(); });
		musicVolumeSlider.onValueChanged.AddListener(delegate { setMusicVolume(); });
		effectVolumeSlider.onValueChanged.AddListener(delegate { setEffectVolume(); });

		if (!PlayerPrefs.HasKey(saveStr)) {
			PlayerPrefs.SetString(saveStr, "1|1|1");
		}

		string[] data = PlayerPrefs.GetString(saveStr).Split('|');

		masterVolumeSlider.value = float.Parse(data[0]);
		musicVolumeSlider.value = float.Parse(data[1]);
		effectVolumeSlider.value = float.Parse(data[2]);

		setMasterVolume();
		setMusicVolume();
		setEffectVolume();

		base.Start();
	}

	private void setMasterVolume() {
		GameManager.instance.soundManager.masterVolume = masterVolumeSlider.value;
		saveVolume();
	}

	private void setMusicVolume() {
		GameManager.instance.soundManager.musicVolume = musicVolumeSlider.value;
		saveVolume();
	}

	private void setEffectVolume() {
		GameManager.instance.soundManager.effectVolume = effectVolumeSlider.value;
		saveVolume();
	}

	private void saveVolume() {
		string data = "";
		data += GameManager.instance.soundManager.masterVolume.ToString() + "|";
		data += GameManager.instance.soundManager.musicVolume.ToString() + "|";
		data += GameManager.instance.soundManager.effectVolume.ToString();

		PlayerPrefs.SetString(saveStr, data);
	}


}
