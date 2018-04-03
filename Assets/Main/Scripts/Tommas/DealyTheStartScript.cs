using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealyTheStartScript : MonoBehaviour {


    [Header("GetTheCamera")]
    [SerializeField] private GameObject countDown;
    public static GameObject[] Levels; 

    
	// Use this for initialization
	void Start () {
        StartCoroutine("StartCount");
	}
	

	// Update is called once per frame
	void Update () {

        //Syntax for forskjellige anim(per scene)
        if( Levels.Length == 0)
        {
            GetComponent<Animation>(); 
        }
	}


    IEnumerator StartCount()
    {
        Time.timeScale = 0f;
        float pauseTimer = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup > pauseTimer)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 3; 

    }
}
