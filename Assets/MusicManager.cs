using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {
    public float MusicTimer;
    public int numberOfDifferentSongs;
    public int currentScene2;
    public AudioSource[] audioClip;
    public AudioClip clip;
    public bool hasAddedSong = false;
    
    public float delay;


    public void Start()
    {
        AudioSource[] audioClip = GetComponents<AudioSource>();
    }
    void Update()
    {
        currentScene2 = (SceneManager.GetActiveScene().buildIndex + numberOfDifferentSongs);
        MusicTimer -= Time.deltaTime;
        CheckMusicTimer();
    

        if(currentScene2 == 2)
        {
            audioClip[currentScene2 - 1].loop = false;
        }

        if (currentScene2 == 3)
        {
            audioClip[currentScene2 - 1].loop = false;
        }

        if (currentScene2 == 4)
        {
            audioClip[currentScene2 - 1].loop = false;
        }
        if (currentScene2 == 5)
        {
            audioClip[currentScene2 - 1].loop = false;
        }
        if (currentScene2 == 6)
        {
            audioClip[currentScene2 - 1].loop = false;
        }
        if (currentScene2 == 7)
        {
            audioClip[currentScene2 - 1].loop = false;
        }
        if (currentScene2 == 8)
        {
            audioClip[currentScene2 - 1].loop = false;
        }

        print("Current Scene: " + currentScene2);

    }

        //CheckSoundsToPlay();

    public void Play(int input)
    {
        if (!audioClip[input].isPlaying)
        {
            audioClip[input].Play();
        }

    }


    public void CheckMusicTimer()
    {

        if (currentScene2 == 0 && MusicTimer <= 0)
        {
            Debug.Log("Nr 1 is playing");
            MusicTimer = audioClip[currentScene2].clip.length - audioClip[currentScene2].time;
            Play(currentScene2);
            numberOfDifferentSongs = numberOfDifferentSongs + 1;
            hasAddedSong = true;  
        }

        if (currentScene2 == 1 && MusicTimer <= 0)
        {
            Debug.Log("Nr 2 is playing");
            MusicTimer = audioClip[currentScene2].clip.length - audioClip[currentScene2].time;
            Play(currentScene2);
        }

        if (currentScene2 == 2 && MusicTimer <= 0)
        {
            if (audioClip[currentScene2 -1].loop == false)
            {
                Debug.Log("Nr 3 is playing");
                Play(currentScene2);
                MusicTimer = audioClip[currentScene2].clip.length - audioClip[currentScene2].time;
                Play(currentScene2);
            }
        }

        if (currentScene2 == 3 && MusicTimer <= 0)
        {
            if (audioClip[currentScene2-1].loop == false)
            {
                Debug.Log("Nr 4 is playing");
                Play(currentScene2);
                MusicTimer = audioClip[currentScene2].clip.length - audioClip[currentScene2].time;
                Play(currentScene2);
            }
        }

        if (currentScene2 == 4 && MusicTimer < 0)
        {
            Debug.Log("Nr 4 is playing");
            Play(currentScene2);
            if (audioClip[currentScene2-1].loop == false)
            {
                MusicTimer = audioClip[currentScene2].clip.length - audioClip[currentScene2].time;
                Play(currentScene2);
            }
        }

        /* if (SceneManager.GetActiveScene().buildIndex == 4 && MusicTimer > 0)
         {
             MusicTimer = 8;
         }

         if (SceneManager.GetActiveScene().buildIndex == 5 && MusicTimer < 0)
         {
             MusicTimer = 8;
         }

         if (SceneManager.GetActiveScene().buildIndex == 6 && MusicTimer < 0)
         {
             MusicTimer = 8;
         }
         if (SceneManager.GetActiveScene().buildIndex == 7 && MusicTimer < 0)
             MusicTimer = 8;
         if (SceneManager.GetActiveScene().buildIndex == 8 && MusicTimer < 0)
             MusicTimer = 8;
         if (SceneManager.GetActiveScene().buildIndex == 9 && MusicTimer < 0)
             MusicTimer = 8;
         if (SceneManager.GetActiveScene().buildIndex == 10 && MusicTimer < 0)
             MusicTimer = 8;
         if (SceneManager.GetActiveScene().buildIndex == 11 && MusicTimer < 0)
             MusicTimer = 8;
         if (SceneManager.GetActiveScene().buildIndex == 12 && MusicTimer < 0)
             MusicTimer = 8;
         if (SceneManager.GetActiveScene().buildIndex == 13 && MusicTimer < 0)
             MusicTimer = 8;*/

    }

/*
    public void CheckSoundsToPlay()
    {
        if (numberOfDifferentSongs + SceneManager.GetActiveScene().buildIndex > SceneManager.GetActiveScene().buildIndex)
        {
            
            StartCoroutine(WaitForTimer());
        }

    }
    */
    
}
