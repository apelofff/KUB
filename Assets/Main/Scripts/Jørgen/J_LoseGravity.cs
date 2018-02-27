using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_LoseGravity : MonoBehaviour {


	void Start ()
    {
		
	}
    void OnTriggerEnter (Collider other)
    {
		if (other.tag == "antiGravity")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "antiGravity")
        FindObjectOfType<AudioManager>().Play("gravity");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "antiGravity")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
