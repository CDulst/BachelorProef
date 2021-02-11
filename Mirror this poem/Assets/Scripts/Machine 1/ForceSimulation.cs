using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSimulation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, 1200f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, -1200f);
        }
    }
}
