﻿using UnityEngine;

public class dontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);	
	}

}
