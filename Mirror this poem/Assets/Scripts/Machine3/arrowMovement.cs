using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMovement : MonoBehaviour
{
    public PopUp popUp;
    [Range(1,-1)] public float movementFactor;
    [Range(-1, 1)] public float buildingUpFactor;

    public float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        popUp.CreatePopUp();
    }

    // Update is called once per frame
    void Update()
    {
        //goingWild();
        buildingUp();
    }

    public void buildingUp()
    {
        

        if(buildingUpFactor == 1)
        {
            goingWild();
        }else
        {
            transform.rotation = Quaternion.Euler(0, buildingUpFactor * 30+90, 0);
        }
    }

    public void goingWild()
    {
        popUp.deletePopUp();
        float cycles = Time.time / period;
        float tau = Mathf.PI * 10f;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSinWave;
        transform.rotation = Quaternion.Euler(0, movementFactor * 30+90, 0);
    }
}
