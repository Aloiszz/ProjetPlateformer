using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SounSliderEnzoPause : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public Slider musicSlider;
    public Slider atmosphereSlider;
    public Slider soundSlider;

    public static SounSliderEnzoPause instance;
    
    public bool DoOnce;

    private void Awake()
    {
        if (instance == null) instance = this;
        
    }
    
    public void Start()
    {
        musicSlider.onValueChanged.AddListener (delegate {ValueOfMusicChangeCheck(musicSlider.value);});
        atmosphereSlider.onValueChanged.AddListener (delegate {ValueOfAtmosphereChangeCheck(atmosphereSlider.value);});
        soundSlider.onValueChanged.AddListener (delegate {ValueOfSoundChangeCheck(soundSlider.value);});
        
        audioMixer.GetFloat("volume", out float musicValueForSlider);
        if (DoOnce = true)
        {
            musicSlider.value = musicValueForSlider + (1 - 0.09745264f);
            DoOnce = false;
        }
       

        audioMixer.GetFloat("ambiance", out float atmosphereValueForSlider);
        atmosphereSlider.value = atmosphereValueForSlider;

        audioMixer.GetFloat("bruitages", out float soundValueForSlider);
        if (DoOnce)
        {
            soundSlider.value = soundValueForSlider + 4.5f;
            DoOnce = false;
        }
        
    }
    
    public void ValueOfMusicChangeCheck(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void ValueOfAtmosphereChangeCheck(float volume)
    {
        audioMixer.SetFloat("ambiance", volume);
    } 
    public void ValueOfSoundChangeCheck(float volume)
    {
        audioMixer.SetFloat("bruitages", volume);
    }
}
