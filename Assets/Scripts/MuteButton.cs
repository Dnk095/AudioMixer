using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteButton : MonoBehaviour
{

    [SerializeField] private AudioMixerGroup _mixer;

    private Toggle _toggle;

    public event Action UnMute;

    public bool IsMute { get; private set; } = false;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(Mute);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(Mute);
    }

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Mute(bool enabled)
    {
        string MasterVolume = nameof(MasterVolume);

        float minVolume = -80;

        IsMute = !enabled;

        if (enabled)
            UnMute?.Invoke();
        else if (enabled == false)
            _mixer.audioMixer.SetFloat(MasterVolume, minVolume);
    }
}