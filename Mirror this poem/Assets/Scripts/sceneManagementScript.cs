using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class sceneManagementScript : MonoBehaviour
{
    public TriggerController TriggerControllerScript;
    public BodySourceView BodySourceViewScript;
    public TransitionLoader transitionScript;
    public GameObject cameraManagement;
    public CubeSpinningAnimation cubeScript;

    private PlayableDirector animationControl;
    private bool runOnce = false;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject TriggerController = GameObject.Find("TriggerController");
        TriggerControllerScript = TriggerController.GetComponent<TriggerController>();
        GameObject BodySourceView = GameObject.Find("KinectAvatar");
        BodySourceViewScript = BodySourceView.GetComponent<BodySourceView>();
        GameObject TransitionLoader = GameObject.Find("TransitionLoader");
        transitionScript = TransitionLoader.GetComponent<TransitionLoader>();
        GameObject cubeSpinningAnim = GameObject.Find("Cube");
        //cubeScript = cubeSpinningAnim.GetComponent<CubeSpinningAnimation>();

        animationControl = cameraManagement.GetComponent<PlayableDirector>();

        


    }

    // Update is called once per frame
    void Update()
    {
        PuzzleWin();
        ManageCamera();
    }

    private void PuzzleWin()
    {
        if (TriggerControllerScript.AfterDelayWin == true)
        {
            transitionScript.LoadNextScene();
            //cubeScript.cubeSpinning();
            //SceneManager.LoadScene(1);
        }
    }

    private void ManageCamera ()
    {
        if(BodySourceViewScript.alreadyConnected == true)
        {
            if(!runOnce)
            {
                animationControl.Play();
                runOnce = true;
            }
            
        }else
        {
            runOnce = false;  
        }
    }
}
