using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    [SerializeField] private float randomNumberRot = 40; 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, randomNumberRot * Time.deltaTime);
    }
}
