using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleCheck : MonoBehaviour
{
    public Machine4Animation anim;
    public bool ready;

    public void Start()
    {
        anim = FindObjectOfType<Machine4Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Marble")
        {
           if (ready)
            {
                    anim.LeftUp();
                    Debug.Log("Left");
           }
            ready = false;
        } 
        }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Wait());

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        ready = true;
    }

 

}
