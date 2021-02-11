using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine4Animation : MonoBehaviour
{

    public Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void NeutralLeft()
    {
        animator.SetBool("NeutralLeft", true);
    }

    public void NeutralRight()
    {
        animator.SetBool("NeutralRight", true);
    }

    public void LeftUp()
    {
        animator.SetBool("RightUp", false);
        animator.SetBool("LeftUp", true);
    }

    public void RightUp()
    {
        animator.SetBool("LeftUp", false);
        animator.SetBool("RightUp", true);
    }
}
