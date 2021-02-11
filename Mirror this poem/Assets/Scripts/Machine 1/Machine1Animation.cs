using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine1Animation : MonoBehaviour
{
    public bool toggle;
    public ParticleSystem particleLeft;
    public ParticleSystem particleRight;
    public bool canDissapear = false;
    public PopUp popUp;
    public GameObject popUpObject;


    private void Start()
    {
        popUp = popUpObject.GetComponent<PopUp>();
        popUp.CreatePopUp();
        

    }
    public void Hit(string side, LampController lamp)
    {
        if (!toggle)
        {
            if (side == "left")
            {
                lamp.NextLight();
                LeftSide();
                toggle = true;
                particleRight.Play();
                popUp.deletePopUp();
                
            }
        }
        else
        {
           if (side == "right") {
               lamp.NextLight();
                RightSide();
                toggle = false;
                particleLeft.Play();
                popUp.deletePopUp();
                
            }
        }
    }

   
    public void LeftSide()
    {
        gameObject.GetComponent<Animator>().SetBool("RightHit", false);
        gameObject.GetComponent<Animator>().SetBool("LeftHit", true);
    }
    public void RightSide()
    {
        gameObject.GetComponent<Animator>().SetBool("LeftHit", false);
        gameObject.GetComponent<Animator>().SetBool("RightHit", true);
    }
}
