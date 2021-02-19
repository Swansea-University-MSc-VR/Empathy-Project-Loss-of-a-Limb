using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon; 

public class AWSInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityInitializer.AttachToGameObject(this.gameObject); // this starts AWS it has a terrible name! can only be one!
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest; // this use Http client useind the unity web requests
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

