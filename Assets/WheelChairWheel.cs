using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairWheel : MonoBehaviour
{
    public bool beingPushed;
    public enum WheelType
    {
        Left,
        Right,
    }

    public WheelType wheelType;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (wheelType == WheelType.Left)
        {

            if (Input.GetKey(KeyCode.Q))
            {
                beingPushed = true;
            }
            else
            {
                beingPushed = false;
            }
        }

        if (wheelType == WheelType.Right)
        {

            if (Input.GetKey(KeyCode.E))
            {
                beingPushed = true;
            }
            else
            {
                beingPushed = false;
            }
        }

    }
}

