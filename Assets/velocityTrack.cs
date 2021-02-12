using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityTrack : MonoBehaviour
{
    public float CurrentYPos;
    public float PreviousYPos;
    public float velocity;
    public float velocityClamp;
    public float velocityModifier = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentYPos = transform.position.y;
        velocity = ((CurrentYPos - PreviousYPos) / Time.deltaTime) ;
        velocityClamp = Mathf.Clamp(velocity, 0.0f, 2.0f) * velocityModifier;
        PreviousYPos = CurrentYPos;
    }
}
