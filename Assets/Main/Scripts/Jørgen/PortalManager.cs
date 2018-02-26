using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{

    public List <GameObject> nextPortal = new List<GameObject>();
    public Vector3 pos;
    public int portalCounter;
    public bool isInTrigger;

    private void Start()
    {
        portalCounter = 0;
        pos = nextPortal[portalCounter].transform.position;
    }

    private void Update()
    {
        Debug.Log(transform.position);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "portal")
        {
            transform.position = pos;
        }
    }

}
