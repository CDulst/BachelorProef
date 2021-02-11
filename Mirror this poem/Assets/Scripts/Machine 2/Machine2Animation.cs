using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine2Animation : MonoBehaviour
{
    public Animator animator;
    public PopUp popUp;

    public Machine2Audio audiosrc;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audiosrc = FindObjectOfType<Machine2Audio>();
        popUp.CreatePopUp();



    }

    public void StartUp()
    {
        animator.SetBool("Halted", false);
        animator.SetBool("StartUp", true);
        audiosrc.StartProjector();
        popUp.deletePopUp();
    }

    public void Halted()
    {
        animator.SetBool("Stopping", false);
        animator.SetBool("Halted", true);
    }

    public void Stopping()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Stopping", true);
    }

    public void Running()
    {
        audiosrc.RunningProjector();
        animator.SetBool("StartUp", false);
        animator.SetBool("Running", true);
    }
}
