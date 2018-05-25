using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager2 : MonoBehaviour
{

    public AudioSource AS1;
    public AudioSource AS2;
    private MusicManager2 instance;
    public AudioClip[] LEVELCLIP;
    public int currentScene;
    private int numberOfLongerSongs;

   /* void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }*/

    void Start ()
    {
        AS1 = gameObject.GetComponent<AudioSource>();
        AS2 = gameObject.GetComponent<AudioSource>();

        currentScene = SceneManager.GetActiveScene().buildIndex;
        AS1.clip = LEVELCLIP[currentScene];
        AS1.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        AS1IsPlaying();


    }

    public void AS1IsPlaying()
    {
        AS2.clip = LEVELCLIP[currentScene];
        AS1.clip = LEVELCLIP[currentScene];

        if (!AS1.isPlaying)
        {
            AS2.UnPause();
            AS1.Play();
            AS1.Pause();
        }

        if (!AS2.isPlaying)
        {
            AS2.UnPause();
            AS1.Play();
            AS1.Pause();
        }
    }
}
