using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{

    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isMute = false;

    public void Mute(bool enabled)
    {
        if (_isMute == false)
        {
            _isMute = true;
            _mixer.audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            _isMute = false;
            _mixer.audioMixer.SetFloat("MasterVolume", -80);
        }
    }


    public void ChangeSoundValue(float volume)
    {
        _mixer.audioMixer.SetFloat("SoundVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeBackGroundVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("BackGroundVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
}
