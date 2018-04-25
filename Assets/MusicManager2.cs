using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager2 : MonoBehaviour
{

    public AudioSource AS1;
    public AudioSource AS2;
    public MusicManager2 instance;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        AS1 = gameObject.GetComponent<AudioSource>();
        AS2 = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
