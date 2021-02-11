using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPuzzle : MonoBehaviour
{

    public GameObject prefabFeedback;
    public BodySourceView kinectScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject kinect = GameObject.Find("KinectAvatar");
        kinectScript = kinect.GetComponent<BodySourceView>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (kinectScript.alreadyConnected)
        {
            StartCoroutine(WaitTimeRunning());
            prefabFeedback.transform.position = transform.position;
        }
        else
        {
            prefabFeedback.SetActive(false);
        }

    }

    public IEnumerator WaitTimeRunning()
    {
        yield return new WaitForSeconds(15);
        prefabFeedback.SetActive(true);
    }
}
