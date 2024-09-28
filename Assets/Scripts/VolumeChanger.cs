using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private string _sliderName;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private MuteButton _muteButton;

    private Slider _slider;

    private float currentVolume = 0;

    public event Action<string, float> OnVolumeChange;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
        _muteButton.UnMute += OnUnMute;
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
        _muteButton.UnMute -= OnUnMute;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void ChangeVolume(float volume)
    {
        float minVolume = -80;

        currentVolume = volume;

        if (_muteButton.IsMute)
            return;

        if (volume <= 0.02)
            _mixer.audioMixer.SetFloat(_sliderName, minVolume);
        else if (volume > 0.02)
            _mixer.audioMixer.SetFloat(_sliderName, Mathf.Log10(volume) * 20);
    }

    private void OnUnMute()
    {
        ChangeVolume(currentVolume);
    }
}
