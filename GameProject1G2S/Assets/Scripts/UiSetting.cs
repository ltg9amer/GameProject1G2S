using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UiSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private List<Slider> sliders = new List<Slider>();

    public void AllMute()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void MasterVolume()
    {
        audioMixer.SetFloat("Master", sliders[0].value);
    }

    public void BGMVolume()
    {
        audioMixer.SetFloat("BGM", sliders[1].value);
    }

    public void SFXVolume()
    {
        audioMixer.SetFloat("SFX", sliders[2].value);
    }
}
