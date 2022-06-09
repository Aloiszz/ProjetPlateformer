using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuqiqueManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public int musicIndex = 0;
    public static MuqiqueManager instance;

    public bool MusicStart = true;
    public bool MusicTempete;
    public bool MusicPostTempete;
    public bool MusicRuines;
    public bool GrossePorte;
    public bool Crédits;
    public bool Chargement;

    public bool DoOnce;
    public bool DoOnce2;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource.clip = playlist[0];
        audioSource.Play();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            BoucleSound();
        }

        if (MusicStart)
        {
            musicIndex = 0;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
          /*  MusicStart = true;
            MusicTempete = false;
            MusicPostTempete= false;
            MusicRuines= false;
            GrossePorte= false;
            Crédits= false;*/
        }
        
        if (MusicTempete)
        {
            musicIndex = 1;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
           /* MusicStart = false;
            MusicTempete = true;
            MusicPostTempete= false;
            MusicRuines= false;
            GrossePorte= false;
            Crédits= false;*/
        }
        
        if (MusicPostTempete)
        {
            musicIndex = 2;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
            /*MusicStart = false;
            MusicTempete = false;
            MusicPostTempete= true;
            MusicRuines= false;
            GrossePorte= false;
            Crédits= false;*/
        }
        
        if (MusicRuines)
        {
            musicIndex = 3;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
            /*MusicStart = false;
            MusicTempete = false;
            MusicPostTempete= false;
            MusicRuines= true;
            GrossePorte= false;
            Crédits= false;*/
        }
        
        if (GrossePorte)
        {
            musicIndex = 4;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
            /*MusicStart = false;
            MusicTempete = false;
            MusicPostTempete= false;
            MusicRuines= false;
            GrossePorte= true;
            Crédits= false;*/
        }
        
        if (Crédits)
        {
            musicIndex = 5;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
            /*MusicStart = false;
            MusicTempete = false;
            MusicPostTempete= false;
            MusicRuines= false;
            GrossePorte= false;
            Crédits= true;*/
        }
        
        if (Chargement)
        {
            musicIndex = 6;
            audioSource.clip = playlist[musicIndex];
            audioSource.Play();
            
            /*MusicStart = false;
            MusicTempete = false;
            MusicPostTempete= false;
            MusicRuines= false;
            GrossePorte= false;
            Crédits= true;*/
        }

        if (SceneManager.GetActiveScene().name == "LD Ruines 3")
        {
            StartCoroutine(Music());
        }
        
        if (SceneManager.GetActiveScene().name == "LoadingScreen")
        {
            StartCoroutine(Music2());
        }
    }
    
    IEnumerator Music()
    {
        if (DoOnce2)
        {
            MusicRuines = true;
            yield return new WaitForSeconds(0.5f);
            MusicRuines = false;
            DoOnce2 = false;
        }
      
    }
    
    IEnumerator Music2()
    {
        if (DoOnce)
        {
            Chargement = true;
            yield return new WaitForSeconds(0.5f);
            Chargement = false;
            DoOnce = false;
        }
     
    }

    void BoucleSound()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
