using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string SoundVolume = nameof(SoundVolume);
    private const string BackGroundVolume = nameof(BackGroundVolume);

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private VolumeChanger _soundSlider;
    [SerializeField] private VolumeChanger _masterSlider;
    [SerializeField] private VolumeChanger _backGroundSlider;
    [SerializeField] private Toggle _mute;

    private void OnEnable()
    {
        _soundSlider.OnVolumeChange += ChangeVolume;
        _masterSlider.OnVolumeChange += ChangeVolume;
        _backGroundSlider.OnVolumeChange += ChangeVolume;
        _mute.onValueChanged.AddListener(Mute);
    }

    private void OnDisable()
    {
        _soundSlider.OnVolumeChange -= ChangeVolume;
        _masterSlider.OnVolumeChange -= ChangeVolume;
        _backGroundSlider.OnVolumeChange -= ChangeVolume;
        _mute.onValueChanged.RemoveListener(Mute);
    }

    public void Mute(bool enabled)
    {
        if (enabled)
            _mixer.audioMixer.SetFloat(MasterVolume, 0);
        else
            _mixer.audioMixer.SetFloat(MasterVolume, -80);
    }

    private void ChangeVolume(string name, float volume)
    {
        if (volume <= 0.02)
            _mixer.audioMixer.SetFloat(name, -80);
        else
            _mixer.audioMixer.SetFloat(name, Mathf.Log10(volume) * 20);
    }
}