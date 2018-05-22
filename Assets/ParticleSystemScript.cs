using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

    public PortalManager portalScript;
    private bool changeMat;

    public Material newMaterial;
    public Material startingMaterial;


    // Use this for initialization
    void Start ()
    {
        portalScript = GetComponent<PortalManager>();

        changeMat = false;
        gameObject.GetComponent<TrailRenderer>().material = startingMaterial;
        changeMat = portalScript.changeMaterial;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(changeMat == true)
        {
                gameObject.GetComponent<TrailRenderer>().material = newMaterial;
        }
	}

}
