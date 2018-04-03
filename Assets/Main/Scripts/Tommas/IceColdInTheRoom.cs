using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceColdInTheRoom : MonoBehaviour {

    [SerializeField] private float timeStart;
    [SerializeField] private float timeEnd;
    [SerializeField] private bool isItFreezing = false;
    [SerializeField] private int materialArrayInt = 0;

    Material[] materials;
    [SerializeField] private Renderer targetRenderer; 

	// Use this for initialization
	void Start () { 
           
 

	}
	
	// Update is called once per frame
	void Update () {

        timeStart = 10f;



        if (timeStart <= 0f)
        {
            for (materialArrayInt = 0; materialArrayInt < 1; materialArrayInt++)
            {
                Debug.Log("Cahange materialls");
            }
        }
    }
   
}
