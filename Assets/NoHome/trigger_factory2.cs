using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class trigger_factory2 : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Play();
            playableDirector.Play();
            Destroy(gameObject);
        }
    }

}
