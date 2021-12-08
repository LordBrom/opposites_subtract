using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : HideableMenu {

	public Slider masterVolumeSlider;
	public Slider musicVolumeSlider;
	public Slider effectVolumeSlider;

	protected override void Start() {
		masterVolumeSlider.value = GameManager.instance.soundManager.masterVolume;
		musicVolumeSlider.value = GameManager.instance.soundManager.musicVolume;
		effectVolumeSlider.value = GameManager.instance.soundManager.effectVolume;

		masterVolumeSlider.onValueChanged.AddListener(delegate { setMasterVolume(); });
		musicVolumeSlider.onValueChanged.AddListener(delegate { setMusicVolume(); });
		effectVolumeSlider.onValueChanged.AddListener(delegate { setEffectVolume(); });
		base.Start();
	}

	private void setMasterVolume() {
		GameManager.instance.soundManager.masterVolume = masterVolumeSlider.value;
	}

	private void setMusicVolume() {
		GameManager.instance.soundManager.musicVolume = musicVolumeSlider.value;
	}

	private void setEffectVolume() {
		GameManager.instance.soundManager.effectVolume = effectVolumeSlider.value;
	}


}
