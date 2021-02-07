using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWheelChairCont : MonoBehaviour
{
    public void GetInput()
    {
        //m_leftWheelFwd = Input.GetAxis("Horizontal");
        //m_rightWheelFwd = Input.GetAxis("Vertical");
        //m_leftWheelFwd = Input.GetKeyDown("q");
        //m_leftWheelBkwd = Input.GetKeyDown("a");
        //m_rightWheelFwd = Input.GetKeyDown("e");
        //m_rightWheelBkwd = Input.GetKeyDown("d");
       
    }
    void Update()
    {
       
        if (Input.GetKey("q"))
        {
            m_leftWheelFwd = 1;
            Debug.Log("Left Wheel Forward");
        }
        else
        {
            m_leftWheelFwd = 0;
        }
        
        if (Input.GetKey("e"))
        {
            m_rightWheelFwd = 1;
            Debug.Log("Right Wheel Forward");
        }
        else
        {
            m_rightWheelFwd = 0;
        }
    }

    public void Accelerate()
    {
        LeftWheelC.motorTorque = m_leftWheelFwd * motorForce;
        RightWheelC.motorTorque = m_rightWheelFwd * motorForce;
        //LeftWheelC.motorTorque = m_leftWheelBkwd * - motorForce;
        //RightWheelC.motorTorque = m_rightWheelBkwd * - motorForce;
    }

    public void UpdateWheelPoses()
    {
        UpdateWheelPose(LeftWheelC, LeftWheelT);
        UpdateWheelPose(RightWheelC, RightWheelT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat =_transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;

    }

    private void FixedUpdate()
    {
        GetInput();
        Accelerate();
        UpdateWheelPoses();
        
    }
    public float m_leftWheelFwd;
    private float m_leftWheelBkwd;
    public float m_rightWheelFwd;
    private float m_rightWheelBkwd;

    public WheelCollider LeftWheelC;
    public WheelCollider RightWheelC;
    public Transform LeftWheelT;
    public Transform RightWheelT;
    public float motorForce = 20;

    
}
