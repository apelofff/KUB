﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sound {
    public string name;
    public AudioClip clip;

    [Range(0.1f, 3f)]
    public float pitch;
   
    public float reverb;

    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;

    public bool loop;


}
