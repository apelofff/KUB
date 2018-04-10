using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]private Transform PlayerTarget;
    public static bool ISTargetInRange; 
    
	void Start () {
        PlayerTarget = GetComponent<Transform>();
	}

	void Update () {
		if(ISTargetInRange == true) {
            Debug.Log("behavior not implemented"); 
        }
	}
}
