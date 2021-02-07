using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMove : MonoBehaviour
{
    public float turnAmount = 10f;
    public float torque = 10f;
    public float thrust = 1.0f;
    public Rigidbody rb;
    public WheelChairWheel rightWheel;
    public WheelChairWheel leftWheel;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // rb.AddForce(transform.forward * thrust);
        // Short hand version of == true 

        if (rightWheel.beingPushed && leftWheel.beingPushed)
        {
            rb.AddForce(transform.forward * thrust);
        }
        else
        {
            if (rightWheel.beingPushed == true)
            {
                rb.AddTorque(transform.up * torque * -turnAmount);
            }

            if (leftWheel.beingPushed == true)
            {
                rb.AddTorque(transform.up * torque * turnAmount);

            }
        }
    }
}

