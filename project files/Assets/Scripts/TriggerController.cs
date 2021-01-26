using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject goals;
    public List<GameObject> goal;
    public List<bool> status;
    public int childCount;
    public Camera camera;

    public void Start()
    {
        GetChildrenGoals();
        SetStatusses();
    }

    public void GetChildrenGoals()
    {
        childCount = goals.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            goal.Add(goals.transform.GetChild(i).gameObject);
        }
    }

    public void SetStatusses()
    {
        for (int i = 0; i < childCount; i++)
        {
            status.Add(false);
        }
    }

    public void UpdateStatus()
    {
        for (int i = 0; i <  childCount; i++)
        {
            if (goal[i].GetComponent<EnterCheck>().connected)
            {
                status[i] = true;
            }
            else
            {
                status[i] = false;
            }
        }
        CheckFinalStatus();
    }

    public void CheckFinalStatus()
    {
        bool allConnected = true;
        for (int i = 0; i < childCount; i++)
        {
            if (!status[i])
            {
                allConnected = false;
            }
        }
        if (allConnected)
        {
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.green;
        }
        else
        {
            camera.clearFlags = CameraClearFlags.Skybox;
            camera.backgroundColor = Color.white;
        }
        Debug.Log(status);
    }



}

