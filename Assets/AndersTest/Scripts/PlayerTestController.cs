using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour
{

    public float launchForce = 10;


	// Use this for initialization
	void Start () {

    }

    public void LookToMouse()
    {
        if (Input.GetButton("mouse0"))
        {
            Debug.Log("This work?");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
