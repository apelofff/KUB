using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitiyMoving : MonoBehaviour {


    [SerializeField] private Transform thisTransform;
    [SerializeField] private float randomNumberRot;
    [SerializeField] private float checkIf;
    [SerializeField] private float SpeedDir = -1;


    // Getting Components
    private void Start() {

        thisTransform = this.GetComponent<Transform>();
        randomNumberRot = 40;
        checkIf = Random.Range(2f, 1f);

    }

    // Update is called once per frame
    private void Update () {

        thisTransform.Translate(Vector3.up * SpeedDir * checkIf * Time.deltaTime);

	}

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag == "Wall")
        {

            checkIf = checkIf * SpeedDir; 

        }

    }
}
