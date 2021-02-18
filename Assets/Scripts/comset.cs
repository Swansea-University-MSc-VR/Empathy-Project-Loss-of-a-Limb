using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comset : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = com;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
