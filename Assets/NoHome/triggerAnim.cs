using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class triggerAnim : MonoBehaviour {
    public PlayableDirector playableDirector;
    public AudioSource audio;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playableDirector.Play();
            audio.Play();
        }
    }
}
