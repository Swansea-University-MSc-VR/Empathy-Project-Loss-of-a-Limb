using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveOnCollission : MonoBehaviour
{
    
    public GameObject Turn;


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
        if (other.gameObject.tag == "Hand")
        {
           
            Turn.SetActive(true);

            Debug.Log("Collided");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            
            Turn.SetActive(false);
            Debug.Log("stopped Colliding");
        }
    }
    // Update is called once per frame
   // void Update()
   // {
      //  if(Input.GetKey(KeyCode.W))
      //  {
     //       Push.SetActive(true);
      //  }
      //  else
      //  {
     //       Push.SetActive(false);
      //  }
    //}
}
