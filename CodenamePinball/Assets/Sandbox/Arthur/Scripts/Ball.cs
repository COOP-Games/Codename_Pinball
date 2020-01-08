using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    Vector3 direction = new Vector3(0,0,1);

    // cached references
    private Rigidbody body;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }
    }

    private void FixedUpdate() 
    {
        body.MovePosition(body.position + direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) 
    {
        direction = Vector3.Normalize(other.relativeVelocity);
        //body.AddRelativeForce(direction * speed * Time.deltaTime);
    }
}
