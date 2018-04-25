using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalManager : MonoBehaviour
{
    public PlayerControllers playerScript;
    private TrailRenderer lr;
    public GameObject player;
    public Transform portal1;
    public Transform portal2;
    public Transform portal3;
    public Transform portal4;
    public Transform portal5;
    public Transform portal6;
    public Transform portal7;
    public Transform portal8;
    public bool isInTrigger;
    public bool changeMaterial;

    private void Start()
    {
        playerScript = player.GetComponent<PlayerControllers>();
        lr = player.GetComponent<TrailRenderer>();
   }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "portal_1")
        {
            transform.position = portal2.transform.position;
        }
        if (other.tag == "portal_3")
        {
            transform.position = portal4.transform.position;
        }
        if (other.tag == "portal_5")
        {
            transform.position = portal6.transform.position;
        }
        if (other.tag == "portal_7")
        {
            transform.position = portal8.transform.position;
        }
    }

}

