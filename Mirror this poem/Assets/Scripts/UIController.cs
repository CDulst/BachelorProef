using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public string currentController = "";


    public void SetHead()
    {
        currentController = "Head";
        setControllers();
    }

    public void SetBody()
    {
        currentController = "Body";
        setControllers();
    }

    public void SetLeftArm()
    {
        currentController = "LeftArm";
        setControllers();
    }

    public void SetRightArm()
    {
        currentController = "RightArm";
        setControllers();
    }

    public void SetRightLeg()
    {
        currentController = "RightLeg";
        setControllers();
    }

    public void SetLeftLeg()
    {
        currentController = "LeftLeg";
        setControllers();
    }

   public void setControllers()
    {
        FigureController [] objects = FindObjectsOfType<FigureController>();
        foreach(FigureController obj in objects)
        {
            obj.SetCurrentController(currentController);
        }
    }


}
