using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerController : MonoBehaviour
{
    public GameObject goals;
    public List<GameObject> goal;
    public List<bool> status;
    public int childCount;
    public Camera camera;
    private bool winStatus = false;
    private float snapShotTime;
    public bool AfterDelayWin = false;
    public float delay = 3f;

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
        InvokeRepeating("validationWinning", 1f, 0.3f);
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
            snapShotTime = Time.time + delay;   
            winStatus = true;                    
        }
        else
        { 
            winStatus = false;
        }

    }

    public void validationWinning ()
    {
       
        if(winStatus == true)
        {
            if(Time.time > snapShotTime)
            {
                AfterDelayWin = true;
                
            }
            else
            {
                AfterDelayWin = false;
                
            }
        }
    }



}

