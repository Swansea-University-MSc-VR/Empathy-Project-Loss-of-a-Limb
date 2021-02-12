using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectActiveOnCollission : MonoBehaviour
{
    
    public GameObject Turn;
    public InputActionReference XRIntMangr;

    private void OnEnable()
    {
        XRIntMangr.action.performed += GripPressed;
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   // void OnTriggerEnter(Collider other)
   // {
   //     Push.SetActive(true);
   // }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand"  )
        {
           if(XRIntMangr.action.triggered)
            {
                Turn.SetActive(true);
            }
            //Turn.SetActive(true);

            //Debug.Log("Collided");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            
            Turn.SetActive(false);
            //Debug.Log("stopped Colliding");
       }
   }
    // Update is called once per frame
   void Update()
    {
        if(XRIntMangr.action.triggered)
        {
            Debug.Log("Triggered");
            //Turn.SetActive(true);
        }
    }
}
