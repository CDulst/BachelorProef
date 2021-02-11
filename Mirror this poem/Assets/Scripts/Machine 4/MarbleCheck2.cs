using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleCheck2 : MonoBehaviour
{
    public Machine4Animation anim;
    public bool ready;

    public void Start()
    {
        anim = FindObjectOfType<Machine4Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marble")
        {
            if (ready)
            {
                anim.RightUp();
                Debug.Log("Right");
            }
            ready = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ready = true;

    }


}
