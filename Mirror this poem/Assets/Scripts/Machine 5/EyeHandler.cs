using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeHandler : MonoBehaviour
{
    public float drag = 10f;
    public PopUp popUp;
    public bool entered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marble")
        {
            Debug.Log("entered");
            if (!entered)
            {
            entered = true;
            popUp.deletePopUp();
            StartCoroutine(LowerSpeed(other.gameObject));
            }
        }
    }

    void Start()
    {
        popUp.CreatePopUp();
    }

    IEnumerator LowerSpeed(GameObject marble)
    {
        marble.GetComponent<Rigidbody>().drag = drag;
        yield return new WaitForSeconds(1f);
        marble.GetComponent<Rigidbody>().drag = 0;
        StartCoroutine(UpSpeed(marble));
    }

    IEnumerator UpSpeed(GameObject marble)
    {
        yield return new WaitForSeconds(8);
        marble.GetComponent<Rigidbody>().AddForce(0, 0, 500f);
        setEntered();

    }
    public void setEntered()
    {
        entered = false;
    }
}
