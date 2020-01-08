using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    [SerializeField]
    private float restPosition = 0f;
    [SerializeField]
    private float pressedPosition = 45f;
    [SerializeField]
    private float hitStrenght = 1f;
    [SerializeField]
    private float padDamper = 150f;
    [SerializeField]
    string inputName;

    // Cached References
    private HingeJoint hinge;

    // Non-Local Objects
    private JointSpring spring;
    
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();    
        hinge.useSpring = true;
        hinge.useLimits = true;

        spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = padDamper;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
        }else
        {
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
    }
}
