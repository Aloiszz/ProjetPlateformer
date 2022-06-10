using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSliderEnzo : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public Slider musicSlider;
    public Slider atmosphereSlider;
    public Slider soundSlider;

    public void Start()
    {
        //Adds a listener to the slider and invokes a method when the value changes.
        musicSlider.onValueChanged.AddListener (delegate {ValueOfMusicChangeCheck(musicSlider.value);});
        atmosphereSlider.onValueChanged.AddListener (delegate {ValueOfAtmosphereChangeCheck(atmosphereSlider.value);});
        soundSlider.onValueChanged.AddListener (delegate {ValueOfSoundChangeCheck(soundSlider.value);});
        
        audioMixer.GetFloat("volume", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider + (1 - 0.09745264f);

        audioMixer.GetFloat("ambiance", out float atmosphereValueForSlider);
        atmosphereSlider.value = atmosphereValueForSlider;

        audioMixer.GetFloat("bruitages", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider + 4.5f;
        
    }
    
    public void ValueOfMusicChangeCheck(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }
    public void ValueOfAtmosphereChangeCheck(float volume)
    {
        audioMixer.SetFloat("ambiance", Mathf.Log10(volume)*20);
    } 
    public void ValueOfSoundChangeCheck(float volume)
    {
        audioMixer.SetFloat("bruitages", Mathf.Log10(volume)*20);
    }
}
