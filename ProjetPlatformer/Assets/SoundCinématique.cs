using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCinématique : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static SoundCinématique instance;

    public bool TombeDesert;



    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource.clip = playlist[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (TombeDesert)
        {
            musicIndex = 1;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
           /* musicIndex = 0;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();*/
        }
    }
}
