using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassNameThatDoesNotMatch : MonoBehaviour
{
    float sceneLoadTime = 0.0f;
    float waitDuration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoadTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - sceneLoadTime > waitDuration)
        {
            // waited a bit
        }
        else
        {
            // not show the image tracking object
        }
    }
}
