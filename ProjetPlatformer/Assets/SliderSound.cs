using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour
{
   public AudioMixer audioMixer;
   public Slider slider;
   
   public bool Slidermusique;
   public bool Slidereffets;
   public bool Sliderambiance;

   public void Start()
   {
      slider = gameObject.GetComponent<Slider>();
      StartCoroutine(StartSlider());
   }

   IEnumerator StartSlider()
   {
      Debug.Log("ta mère");
      slider.maxValue = 1;
      slider.minValue = 1;
      yield return new WaitForSeconds(0.1f);
      slider.maxValue = 0;
   }

   public void SetVolume (float volume)
   {
      if (Slidermusique)
      {
         audioMixer.SetFloat("volume", volume);
         Debug.Log("sa mère");
      }
      
      if (Sliderambiance)
      {
         audioMixer.SetFloat("ambiance", volume);
      }
      
      if (Slidereffets)
      {
         audioMixer.SetFloat("bruitages", volume);
      }
     
      
   }
}
