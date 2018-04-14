using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Diagnostics;
using System;
using UnityEngine.Animations;


public class MusicManager : MonoBehaviour {
    public float MusicTimer;
    public int numberOfDifferentSongs;
    public int currentScene2;
    public AudioSource[] audioClip;
    private States myState;
    private enum States { s_Level_Start, s_Level_1, s_Level_2, s_Level_3, s_Level_4, s_Level_5, s_Level_6, s_Level_7, s_Level_8, s_Level_9, s_Level_10, }
    public float delta;
    public float lastFrameTime;
    public float delay;

    public void Start()
    {
        AudioSource[] audioClip = GetComponents<AudioSource>();
        myState = States.s_Level_Start;
    }




    private void Update()
    {
        delta = Time.timeSinceLevelLoad - lastFrameTime;
        lastFrameTime = Time.realtimeSinceStartup;

        currentScene2 = (SceneManager.GetActiveScene().buildIndex + numberOfDifferentSongs);
        MusicTimer = MusicTimer - Time.deltaTime;

        print("My State is: " + myState);
        if (MusicTimer <= 0)
        {
            if      (myState == States.s_Level_Start) { State_Level0();  }
            else if (myState == States.s_Level_1) { audioClip[currentScene2 - 1].loop = false; State_Level1();  }
            else if (myState == States.s_Level_2) { audioClip[currentScene2 - 1].loop = false; State_Level2();  }
            else if (myState == States.s_Level_3) { audioClip[currentScene2 - 1].loop = false; State_Level3(); }
            else if (myState == States.s_Level_4) { audioClip[currentScene2 - 1].loop = false; State_Level4(); }
            else if (myState == States.s_Level_5) { audioClip[currentScene2 - 1].loop = false; State_Level5(); }
        }

    }   

    public void Play()
    {
        audioClip[currentScene2].Play();
    }


    private void State_Level10()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 10)
            {
                myState = States.s_Level_10;

            }
            else if (currentScene2 == 10)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }


    private void State_Level9()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 9)
            {
                myState = States.s_Level_10;

            }
            else if (currentScene2 == 9)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }


    private void State_Level8()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 8)
            {
                myState = States.s_Level_4;

            }
            else if (currentScene2 == 8)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }

    private void State_Level7()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 7)
            {
                myState = States.s_Level_4;

            }
            else if (currentScene2 == 6)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }

    private void State_Level6()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 6)
            {
                myState = States.s_Level_4;

            }
            else if (currentScene2 == 6)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }


    private void State_Level5()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 5)
            {
                myState = States.s_Level_4;

            }
            else if (currentScene2 == 5)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }


    private void State_Level4()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 4)
            {
                myState = States.s_Level_4;

            }
            else if (currentScene2 == 4)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }

    private void State_Level3()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;
    
        if (MusicTimer <= 0)
        {
            if (currentScene2 > 3)
            {
                myState = States.s_Level_4;

            }
            else if (currentScene2 == 3)
            {
                audioClip[currentScene2 - 1].loop = false;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }

    private void State_Level2()
    {
        audioClip[currentScene2 - 1].loop = false;
        audioClip[currentScene2 - 2].loop = false;

        if (MusicTimer <= 0)
        {
            if (currentScene2 > 2)
            {
                myState = States.s_Level_3;

            }
            else if(currentScene2 == 2)
            {

                MusicTimer = audioClip[currentScene2].clip.length;
                Play();

            }
        }
    }

    private void State_Level1()
    {
        //audioClip[currentScene2 - 1].loop = false;

        if (MusicTimer <= 0)
        {
            
            if (currentScene2 > 1)
            {
                myState = States.s_Level_2;
                audioClip[currentScene2 - 1].loop = false;
                audioClip[currentScene2 - 2].loop = false;
            }

            if (currentScene2 == 1)
            {

                MusicTimer = audioClip[currentScene2].clip.length;
                Play();
            }
        }
    }

    private void State_Level0()
    {
        if(MusicTimer <= 0)
        {
            if (currentScene2 > 0)
            {
                audioClip[currentScene2 - 1].loop = false;
                myState = States.s_Level_1;
            }

            if (currentScene2 == 0)
            {
                numberOfDifferentSongs = numberOfDifferentSongs + 1;
                MusicTimer = audioClip[currentScene2].clip.length;
                Play();
            }
        }
    }

    //CheckSoundsToPlay();




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




