using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTopLimit : MonoBehaviour
{
    //cached Reference
    [SerializeField]
    private GameObject bridge;

    private void OnTriggerExit(Collider other) 
    {
        this.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(bridge);       
    }
}
