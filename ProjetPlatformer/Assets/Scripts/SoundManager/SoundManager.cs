using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static SoundManager instance;
    
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
        if (!audioSource.isPlaying)
        {
            StartCoroutine(BoucleSoundAmbiance());
        }

    }

    IEnumerator BoucleSoundAmbiance()
    {
        yield return new WaitForSeconds(Random.Range(1, 10));
        if (SceneManager.GetActiveScene().name == "LD Ruines 3")
        {
            audioSource.clip = playlist[Random.Range(1,1)];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = playlist[Random.Range(0,0)];
            audioSource.Play();
        }
    }
}
