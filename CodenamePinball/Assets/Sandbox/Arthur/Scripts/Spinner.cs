using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    int degreesPerSecond = 100;

    [SerializeField]
    int rotationDirection = 1;

    private void Start() {
        rotationDirection = rotationDirection / Mathf.Abs(rotationDirection);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationDirection * degreesPerSecond * Time.deltaTime, 0); //rotates 100 degrees per second around y axis
    }
}
