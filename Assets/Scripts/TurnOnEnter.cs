using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnEnter : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 40f;
    public float torque = 40f;
    public float LinkHandVel;
    public GameObject HandTrack;
    
  
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(transform.up * torque );//* LinkHandVel
        rb.AddForce(transform.forward * thrust ); // * LinkHandVel// 
        LinkHandVel = HandTrack.GetComponent<velocityTrack>().velocityClamp;


    }

   
}

//rb.AddTorque(transform.up * torque * turnAmount);