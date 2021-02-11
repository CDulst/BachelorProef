using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject popUp;
    private GameObject instancePopUp;
    public GameObject lookTowards;
    public Vector3 offset = new Vector3(0, 2, 0);
    public sceneMachinesManager sceneMachinesManager;

    //private GameObject textRenderer;


    public void updatePosition()
    {
        if(instancePopUp != null)
        {
            instancePopUp.transform.position = transform.position + offset;
            Transform transformPosition = lookTowards.transform;
            instancePopUp.transform.LookAt(transformPosition);
            //textRenderer.transform.LookAt(transformPosition);
            
        }

 
    }

    private void Start()
    {
        GameObject sceneManager = GameObject.Find("Scenemanager");
        sceneMachinesManager = sceneManager.GetComponent<sceneMachinesManager>();


        //textRenderer = GameObject.Find("TextRenderer");
    }

    private void Update()
    {
        updatePosition();
    }

    public void deletePopUp()
    {
        if(instancePopUp != null)
        {
            Destroy(instancePopUp);
            sceneMachinesManager.canActivate = true;
        }
            
    }

    public void CreatePopUp()
    {
        GameObject parentPopUp = GameObject.Find("PopUpManager");
        instancePopUp =  Instantiate(popUp, transform.position, transform.rotation);
        instancePopUp.transform.parent = parentPopUp.transform;
    }
}
