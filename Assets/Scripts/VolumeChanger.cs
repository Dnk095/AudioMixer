using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private string _sliderName;

    public event Action<string,float> OnVolumeChange;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        OnVolumeChange?.Invoke(_sliderName, volume);
    }
}
