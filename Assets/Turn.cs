using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 40f;
    public float torque = 40f;
    public float LinkHandVel;
    public GameObject HandTrack;
    public int counter = 0;
    public GameObject Turner;
    public GameObject TurnNested;
    public int TorqueCount = 5;
    public int ThrustCount = 50;
    
  
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddTorque(transform.up * torque );
        rb.AddForce(transform.forward * thrust, ForceMode.Acceleration );
        LinkHandVel = HandTrack.GetComponent<velocityTrack>().velocityClamp;
        if (counter < TorqueCount)
        {
            rb.AddTorque(transform.up * torque);
        }
        if (counter >= ThrustCount)
        {
            counter = 0;
            TurnNested.SetActive(false);
            Turner.SetActive(false);
        }
        else
        {
            counter = counter + 1;
        }

    }

   
}

//rb.AddTorque(transform.up * torque * turnAmount);