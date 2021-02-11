using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMachinesManager : MonoBehaviour
{

    public List<GameObject> machineObjects = new List<GameObject>();
    public List<GameObject> cameraObjects = new List<GameObject>();
    public List<GameObject> textObjects = new List<GameObject>();
    public int incrementation = 0;
    public bool canActivate = false;
    public bool automatic = true;
    public GameObject soundController1;
    public GameObject soundController2;

    private Animator cameraAnimation;
    private AudioSource cameraAudio;


    private void Start()
    {
        incrementation = 0;
    }
    // Update is called once per frame
    void Update()
    {
        setActive();
    }

    public void incrementMachine ()
    {
         incrementation++;
        StartCoroutine(AutomaticPlay());
    }

    public IEnumerator AutomaticPlay()
    {
        yield return new WaitForSeconds(15);
        FindObjectOfType<PopUp>().deletePopUp();
        canActivate = true;
    



    }
    public void setActive()
    {


        machineObjects[incrementation].SetActive(true);
        cameraObjects[incrementation].SetActive(true);

        cameraAnimation = cameraObjects[incrementation].GetComponent<Animator>();
        cameraAudio = machineObjects[incrementation].GetComponent<AudioSource>();

        cameraAnimation.enabled = true;
        cameraAnimation.speed = 0;


        if (incrementation == 6)
        {


            for (int i = 0; i < machineObjects.Count-1; i++){
       
                if (i == 4)
                {
                    machineObjects[i].GetComponent<machine5>().enabled = false;
                }
                machineObjects[i].SetActive(true);
                machineObjects[i].GetComponent<AudioSource>().mute = true;
            }

            soundController1.GetComponent<AudioSource>().mute = true;
            soundController2.GetComponent<AudioSource>().mute = true;
        }

        if (!canActivate)
        {
            cameraAudio.Play();
            cameraAudio.Pause();
        }
        
        if (canActivate) {
            StopAllCoroutines();
            textObjects[incrementation].SetActive(true);
            cameraAnimation.speed = 1;
            cameraAudio.UnPause();
            if(!cameraAudio.isPlaying)
            {
                if (incrementation == machineObjects.Count-1)
                {
                    GotoBeginning();
                }
                else
                {
                    disableMachines();
                    incrementMachine();
                    canActivate = false;
                    
                }
                    

            }
        }
    }
    private void GotoBeginning()
    {
       SceneManager.LoadScene(0);  
    }
    public void disableMachines ()
    {
        machineObjects[incrementation].SetActive(false);
        cameraObjects[incrementation].SetActive(false);
        textObjects[incrementation].SetActive(false);
    }
}
