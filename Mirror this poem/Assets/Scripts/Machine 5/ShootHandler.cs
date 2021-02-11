using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    public GameObject Handle;
    public GameObject upPoint;
    public GameObject downPoint;
    public float DownSpeed = 4f;
    public float Force = 0;
    public bool marbleEntered;
    public GameObject marble;
    public machine5 machineScript;
    public Machine5Audio audiosrc;

    private void Start()
    {
        audiosrc = FindObjectOfType<Machine5Audio>();
        GameObject machine5 = GameObject.Find("Machine5_v2");
        machineScript = machine5.GetComponent<machine5>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Marble")
        {
            marbleEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        marbleEntered = false;
        audiosrc.BallShooting();
    }

    private void Update()
    {
        if (machineScript.canStart)
        {
            if (Handle.transform.position.y > downPoint.transform.position.y)
            {
                
                Handle.transform.position = new Vector3(Handle.transform.position.x, Handle.transform.position.y - DownSpeed*Time.deltaTime, Handle.transform.position.z);
                Force +=400f*Time.deltaTime;
            }
        }
        else
        {
            if (marbleEntered)
            {
                marble.GetComponent<Rigidbody>().AddForce(0, Force, 0);

            }
                Force = 0;
                if (Handle.transform.position.y < upPoint.transform.position.y)
                {
                    Handle.transform.position = new Vector3(Handle.transform.position.x, Handle.transform.position.y + 0.5f, Handle.transform.position.z);
                }
            }
          
        }
    }

