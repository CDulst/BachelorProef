using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer renderer;
    public float y = 0;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        renderer = gameObject.GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
       
        rb.AddRelativeForce(400f, 0f, 400f);
        if(y < 1)
        {
            y += 0.1f;
        }else
        {
            y -= 1;
        }

    }
}
