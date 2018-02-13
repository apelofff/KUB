using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGravity : MonoBehaviour {


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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "antiGravity")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
