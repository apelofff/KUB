using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingPlayerScripts : MonoBehaviour {

    public PlayerControllers playerController;
    public Transform playerTransforme; 


	// Use this for initialization
	void Start () {

        playerController = GetComponent<PlayerControllers>();
        playerTransforme = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length < 1)
            Destroy(this.gameObject);

        if(objs.Length < 1)
        {
            
        }
        
	}
}
