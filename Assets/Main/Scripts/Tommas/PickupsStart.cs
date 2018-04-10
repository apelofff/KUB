using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsStart : MonoBehaviour {


    // Update is called once per frame
    void Update () {
	if (PickUps.IsThisANormalLevel == true) {
            gameObject.SetActive(false); 
        }	
	}
}
