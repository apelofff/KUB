using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorntrigger : MonoBehaviour {


    public Animator anim;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            anim.enabled = true;
            
        }
    }
}

