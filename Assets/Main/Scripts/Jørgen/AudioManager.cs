using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    // Use this for initialization

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }




        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.reverbZoneMix = s.reverb;
            s.loop = false;
            
        }
    }




    public void Play(string name)
    {
        name = name.ToString();

        if (sounds == null)
        {
            Debug.Log("Sound: " + name + " is not found");
            return;
        }
            Sound s = Array.Find(sounds, sound => sound.name == name);

        if(!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

}
