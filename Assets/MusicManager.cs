using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    public float MusicTimer;

    public int numberOfDifferentSongs;
    public bool hasCheckedTime = true;
    public bool hasCheckedTimeIntro = false;
    public string currentScene;
    public string currentScene2;

	
	void Update ()

    {if (SceneManager.GetActiveScene().buildIndex < 0)
            currentScene = SceneManager.GetActiveScene().buildIndex.ToString();

        else currentScene2 = SceneManager.GetActiveScene().buildIndex + numberOfDifferentSongs.ToString();
        CheckMusicTimer();
        CheckSoundsToPlay();
    }


    public void CheckMusicTimer()
    {
        MusicTimer -= Time.deltaTime;

        if (SceneManager.GetActiveScene().buildIndex == 0 && hasCheckedTimeIntro == false)
        {
            MusicTimer = 20;
            hasCheckedTimeIntro = true;
            FindObjectOfType<AudioManager>().Play(currentScene2);
            StartCoroutine(WaitForTimer());
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && MusicTimer < 0 || hasCheckedTimeIntro == true && MusicTimer < 0)
        {
            MusicTimer = 8;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && MusicTimer < 0)
        {
            MusicTimer = 8;

        }

        if (SceneManager.GetActiveScene().buildIndex == 3 && MusicTimer < 0)
        {
            MusicTimer = 8;
        }

        if (SceneManager.GetActiveScene().buildIndex == 4 && MusicTimer < 0)
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
            MusicTimer = 8;

    }


    public void CheckSoundsToPlay()
    {
        if (numberOfDifferentSongs + SceneManager.GetActiveScene().buildIndex > SceneManager.GetActiveScene().buildIndex)
        {
            FindObjectOfType<AudioManager>().Play(currentScene2);
            StartCoroutine(WaitForTimer());
        }

    }

    private IEnumerator WaitForTimer()
    {

        yield return new WaitForSeconds(MusicTimer);
    }

}
