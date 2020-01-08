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
        if(limitP1)
        {
            limitP1.GetComponent<BoxCollider>().isTrigger = false;
        }
    
        if(limitP2)
        {
            limitP2.GetComponent<BoxCollider>().isTrigger = false;
        }
        
        Destroy(bridge);       
    }
}
