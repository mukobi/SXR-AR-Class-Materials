using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject go;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyFunction();
        }
    }

    void MyFunction()
    {
        Debug.Log($"Jumped from {go.name}");
        rb.AddForce(0, Force, 0);
    }
}
