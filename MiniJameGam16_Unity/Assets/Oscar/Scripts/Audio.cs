using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetMasterVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("SoundEffectsVolume", volume);
    }
}
