using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class dontDestroy : MonoBehaviour {

    MusicManager _MusicManager;

    private static dontDestroy instance;
    public void Start()
    {
         _MusicManager = GameObject.Find("GameManager").GetComponent<MusicManager>();
    }
    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);	
	}

}
