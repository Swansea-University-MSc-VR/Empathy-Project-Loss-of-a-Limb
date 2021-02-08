using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 1.0f;
    public float torque = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(transform.up * torque);
        rb.AddForce(transform.forward * thrust);
    }
}

//rb.AddTorque(transform.up * torque * turnAmount);