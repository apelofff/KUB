using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation : MonoBehaviour {

    public PlayerControllers normalScript;
   // public PlayerScriptWithDifferentRotation rotationScript;
    public GameObject Player;
    private float timeLefft;
    private ActivateRotation activateRotation;
    private bool used = false;


    private void Start()
    {
        normalScript = Player.GetComponent<PlayerControllers>();
        //rotationScript = Player.GetComponent<PlayerScriptWithDifferentRotation>();
        activateRotation = Player.GetComponent<ActivateRotation>();

        normalScript.enabled = true;
       // rotationScript.enabled = false;
        
    }

    public void Update()
    {
        timeLefft = activateRotation.timeLeft;

        if (timeLefft <= 0 && used == false)
        {
          //  rotationScript.enabled = false;
            normalScript.enabled = true;
            used = true;
        }

        else if(timeLefft > 0 && used == false)
        {
            //rotationScript.enabled = true;
            normalScript.enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            
        }

        if (timeLefft == -1)
        {
            gameObject.SetActive(false);
        }
    }
}
