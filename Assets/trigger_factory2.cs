﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class trigger_factory2 : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playableDirector.Play();
            Destroy(gameObject);
        }
    }

}
