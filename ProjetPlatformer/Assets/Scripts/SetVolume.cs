using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public bool Slidermusique;
    public bool Slidereffets;
    public bool Sliderambiance;
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        //if (Slidermusique)
        //{
            mixer.SetFloat("music", sliderValue);
            Debug.Log("change");
       // }
        
        //if (Slidereffets)
       // {
            mixer.SetFloat("SoundEffect", Mathf.Log10(sliderValue)*20);
       // }
        
        if (Sliderambiance)
        {
            mixer.SetFloat("Ambiance", Mathf.Log10(sliderValue)*20);
        }
       
    }
}
