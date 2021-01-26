using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCheck : MonoBehaviour
{

    public string TriggerTag;
    public Material connnected;
    public Material unConnected;
    public TriggerController triggerController;
    public bool connected;


    public void Start()
    {
        triggerController = FindObjectOfType<TriggerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TriggerTag)
        {

            Debug.Log(other.tag);
            Debug.Log(TriggerTag);
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = connnected;
            SetConnected(true);
        }
    }

    public void SetConnected(bool status)
    {
        connected = status;
        triggerController.UpdateStatus();
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == TriggerTag)
        {
            Debug.Log("BYEEEEEEEE");
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = unConnected;
            SetConnected(false);
        }
    }
}
