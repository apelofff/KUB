using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioSource audio1;
    private int currentScene;
    public AudioClip[] audioClips;
    public float volumeLoss = 0;
    public float audioLossLenght;
    public float audioGainLenght;
    private float audioLevelSet;
    public int[] levelsToTransition;
    private bool isTransitioning;

    public static MusicManager instance;
    // Use this for initialization

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            return;
        }
    }
    public void Update()
    {
        CheckIfReadyForTransition();
    }

    private void Start()
    {
        
        audio1 = GetComponent<AudioSource>();
        audioLevelSet = audio1.volume;
    }

    public void CheckIfReadyForTransition()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y > currentScene)
        {
            currentScene = y;
            isTransitioning = true;

        }
    }

    public void Transition()
    {
        isTransitioning = true;
        audio1.volume = Mathf.Lerp(audio1.volume, volumeLoss, audioLossLenght);
        StartCoroutine(WaitForFade1());
        audio1.clip = audioClips[SceneManager.GetActiveScene().buildIndex];
        audio1.volume = Mathf.Lerp(audio1.volume, audioLevelSet, audioGainLenght);
    }

    public IEnumerator WaitForFade1()
    {
        yield return new WaitForSeconds(audioLossLenght);
    }
}

