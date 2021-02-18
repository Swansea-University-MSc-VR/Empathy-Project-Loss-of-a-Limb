using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCont : MonoBehaviour
{
    public bool Collided;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log ("Collided");
    }
        
}
