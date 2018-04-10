using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform portal1;
    public Transform portal2;
    public bool isInTrigger;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "portal_1")
        {
            transform.position = portal2.transform.position;
            isInTrigger = true;
        }
    }
}
