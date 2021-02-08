using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionTracker : MonoBehaviour
{
    // the VR camera in the XR rig
    public GameObject LeftHand;
    public GameObject RightHand;
    // A character controller component attached to the XR rig
    public GameObject LHandObj;
    public GameObject RHandObj;
    // private X & Y properties used to store the position of the camera X & Y
    private float xL, yL, zL, xR, yR, zR;



    // Update is called once per frame
    void Update()
    {
        // assign the X and Y values from the camera to the declared variables
        xL = LeftHand.transform.position.x;
        zL = LeftHand.transform.position.z;
        yL = LeftHand.transform.position.y;
        xR = RightHand.transform.position.x;
        zR = RightHand.transform.position.z;
        yR = RightHand.transform.position.y;

       

        // update the centre of the character controller to the main camera so the controller follows the VR camera
        LHandObj.transform.position = new Vector3(xL, yL, zL);
        RHandObj.transform.position = new Vector3(xR, yR, zR);

    }
}
