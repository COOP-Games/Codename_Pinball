using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTopLimit : MonoBehaviour
{
    //cached Reference
    [SerializeField]
    private GameObject bridge;

    [SerializeField]
    private GameObject limitP1;

    [SerializeField]
    private GameObject limitP2;

    private void OnTriggerExit(Collider other) 
    {
        limitP1.GetComponent<BoxCollider>().isTrigger = false;
        limitP2.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(bridge);       
    }
}
