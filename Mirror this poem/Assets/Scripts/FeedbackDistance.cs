using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackDistance : MonoBehaviour
{
    private BodySourceView KinectScript;
    public PopUp popUp;
    private Light light1;
    private Light light2;
    private Light light3;
    private Light light4;
    private Light light5;


    public GameObject light1object;
    public GameObject light2object;
    public GameObject light3object;
    public GameObject light4object;
    public GameObject light5object;

    private bool RunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject kinectAvatar = GameObject.Find("KinectAvatar");
        KinectScript = kinectAvatar.GetComponent<BodySourceView>();

        light1 = light1object.GetComponent<Light>();
        light2 = light2object.GetComponent<Light>();
        light3 = light3object.GetComponent<Light>();
        light4 = light4object.GetComponent<Light>();
        light5 = light5object.GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        toFarOrToClose();

    }

    private void toFarOrToClose()
    {
        if (KinectScript.toFar || KinectScript.toClose)
        {
            if (!RunOnce && KinectScript.alreadyConnected)
            {
                popUp.CreatePopUp();
                changeLightsToRed();
                RunOnce = true;
            }

        }
        else
        {

            RunOnce = false;
            popUp.deletePopUp();
            changeLightsToWhite();
        }
    }

    private void changeLightsToRed()
    {
        light1.color = Color.red;
        light2.color = Color.red;
        light3.color = Color.red;
        light4.color = Color.red;
        light5.color = Color.red;

    }

    private void changeLightsToWhite()
    {
        light1.color = Color.white;
        light2.color = Color.white;
        light3.color = Color.white;
        light4.color = Color.white;
        light5.color = Color.white;

    }
}
