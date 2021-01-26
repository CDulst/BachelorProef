using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class FigureController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 150.0f;
    public float horizontalInput;
    public float forwardInput;
    public float xRange = 6.0f;
    public float zRange = 9.0f;
    public string currentController = "";




    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == currentController)
        {
            horizontalInput = Input.GetAxis("Vertical");
            forwardInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.left, turnSpeed * horizontalInput * Time.deltaTime);
            transform.Rotate(Vector3.up, turnSpeed * forwardInput * Time.deltaTime);
        }
    }

    public void SetCurrentController(string c)
    {
        currentController = c;
    }
}




