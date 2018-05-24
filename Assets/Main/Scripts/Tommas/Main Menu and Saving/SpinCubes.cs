using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SpinCubes : MonoBehaviour {
    public float tempRotasjon = 1f;
    public float ShoothingSpeed = 1000f; 
    public Rigidbody Target1;

    public static bool Fade = false;

	// Use this for initialization
	void Start () {
       
        Target1 = GetComponent<Rigidbody>(); 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Target1.transform.Rotate(0, 0, Time.deltaTime * tempRotasjon);
        } else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Target1.AddForce(transform.right * ShoothingSpeed); 
        }
       
	}
    public void InvokePlay()
    {
        Fade = false; 
        Invoke("PlayQb", 1f); 
    }

    public void PlayQb()
    {
        Fade = true; 
        SceneManager.LoadScene("Tutorial1");

    }
}
