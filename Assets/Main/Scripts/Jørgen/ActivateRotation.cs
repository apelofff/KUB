using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRotation : MonoBehaviour {

    public GameObject rotationChanger;
    private ChangeRotation rotationScript;
    public float timeLeft;
	

	void Start ()
    {
        rotationScript = rotationChanger.GetComponent<ChangeRotation>();

	}

    public void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;
    }
    private void OnTriggerEnter(Collider RotChanger)
    {
        if (RotChanger.tag == "RotationChange")
        {
            timeLeft = 30;
        }
    }
}
