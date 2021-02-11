using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzlebehaviour : MonoBehaviour
{

    public GameObject handLeft;
    public GameObject handRight;
    public GameObject kneeLeft;
    public GameObject kneeRight;
    public GameObject head;
    public GameObject center2;
    public GameObject center;
    public GameObject limbPositionsColliders;

    public BodySourceView kinectScript;

    private void Start()
    {
        GameObject kinect = GameObject.Find("KinectAvatar");
        kinectScript = kinect.GetComponent<BodySourceView>();
    }

    private void Update()
    {
        if(kinectScript.alreadyConnected == true)
        {
            limbPositionsColliders.SetActive(true);

        
            if(handLeft)
            {
                handLeftAction(handLeft, kinectScript.manoIzk);
            }

            if(handRight)
            {
                handRightAction(handRight, kinectScript.manoDer); 

            }

            if (kneeLeft)
            {
                kneeLeftAction(kneeLeft, kinectScript.rodillaIzk);
            }

            if(kneeRight)
            {
                kneeRightAction(kneeRight, kinectScript.rodillaDer);
            }

            if(head)
            {
                headAction(head, kinectScript.cabezaHead2);
                headAction(limbPositionsColliders, kinectScript.cabezaHead2);
            }

            if(center2)
            {
                center2Action(center2, kinectScript.cabezaHead2);
            }

            if(center)
            {
                centerAction(center, kinectScript.pelvisSpineBase);
                
            }
        }
        else
        {
            limbPositionsColliders.SetActive(false);
        }
    }

    public void handLeftAction (GameObject handLeft, Vector3 handLeftCoord)
    {
        handLeft.transform.position = new Vector3(handLeftCoord.x + 1 / 5, handLeftCoord.y - 1 / 2, handLeftCoord.z);
    }

    public void handRightAction(GameObject handRight, Vector3 handRightCoord)
    {
        handRight.transform.position = new Vector3(handRightCoord.x - 1 / 2, handRightCoord.y - 1 / 2, handRightCoord.z);
    }

    public void kneeLeftAction (GameObject kneeLeft, Vector3 kneeLeftCoord)
    {
        kneeLeft.transform.position = new Vector3(kneeLeftCoord.x - 0.50f, kneeLeftCoord.y + 1.40f, kneeLeftCoord.z);
    }

    public void kneeRightAction (GameObject kneeRight, Vector3 kneeRightCoord)
    {
        kneeRight.transform.position = new Vector3(kneeRightCoord.x + 0.50f, kneeRightCoord.y + 1.40f, kneeRightCoord.z);
    }

    public void headAction (GameObject head, Vector3 headCoord)
    {
        head.transform.position = new Vector3(headCoord.x, headCoord.y - 1, headCoord.z);
    }

    public void center2Action (GameObject center2, Vector3 center2Coord)
    {
        center2.transform.position = new Vector3(center2Coord.x, center2Coord.y - 3, center2Coord.z);
    }

    public void centerAction (GameObject center, Vector3 centerCoord)
    {
        center.transform.position = new Vector3(centerCoord.x, centerCoord.y + 2, centerCoord.z);
    }

}
