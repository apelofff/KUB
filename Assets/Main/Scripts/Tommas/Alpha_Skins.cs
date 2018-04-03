using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_Skins : MonoBehaviour {

    [SerializeField] private bool IsGold = false ;
    [SerializeField] private bool ISspecialskin = false;
    

    public Material[] material;
    Renderer rendering;


	// Use this for initialization
	void Start () {

        rendering = GetComponent<Renderer>();
        rendering.enabled = true;
        rendering.sharedMaterial = material[0];

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gold")
        {
            rendering.sharedMaterial = material[1];
        }


        if (other.tag == "SpecialSkin")
        {
            rendering.sharedMaterial = material[2];
        }

        if (other.tag == "Funnyskin")
        {
            rendering.sharedMaterial = material[3];
        }
    }
}
