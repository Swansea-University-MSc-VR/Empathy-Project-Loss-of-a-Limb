using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectActiveOnCollission : MonoBehaviour
{
    
    public GameObject Turn;
    public GameObject TurnNested;
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

   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand"  )
        {
            //TurnNested.SetActive(false);
            Turn.SetActive(true);

           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (TurnNested.gameObject.activeSelf)
        {

            Debug.Log("Pushed");
            
        }
        else
        {
            Turn.SetActive(false);
        }
   }
    // Update is called once per frame
   void Update()
    {
        
        if (XRIntMangr.action.triggered && Turn.gameObject.activeInHierarchy)
        {
            Debug.Log("Triggered");
            TurnNested.SetActive(true);
        }
    }
}
