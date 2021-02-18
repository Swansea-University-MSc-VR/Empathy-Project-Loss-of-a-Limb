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
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 5)
        {
            CurrentYPos = transform.position.y;
            velocity = ((CurrentYPos - PreviousYPos) / Time.deltaTime);
            velocityClamp = Mathf.Clamp(velocity, 0.0f, 10f) ;
            PreviousYPos = CurrentYPos;
            counter = 0;
        }
        else
        {
            counter = counter + 1;
        }
        
    }
}
