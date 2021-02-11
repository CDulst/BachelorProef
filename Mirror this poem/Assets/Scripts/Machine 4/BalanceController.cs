using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceController : MonoBehaviour
{
    public Machine4Animation animator;
    public List<Rigidbody> balls;
    public machine4 machine4Script;
    public PopUp popUP;
    public bool started;
    public Machine3Audio audiosrc;
    // Update is called once per frame
    public void Start()
    {
        animator = GetComponent<Machine4Animation>();
        popUP.CreatePopUp();
        GameObject machine4 = GameObject.Find("Machine4");
        machine4Script = machine4.GetComponent<machine4>();
        audiosrc = FindObjectOfType<Machine3Audio>();
    }
    void Update()
    {
        if (machine4Script.canStartRight)
        {
            if (!started)
            {
                popUP.deletePopUp();
                started = true;
                animator.NeutralLeft();
            }
        }
        if (machine4Script.canStartLeft)
        {
            if (!started)
            {
                popUP.deletePopUp();
                started = true;
                animator.NeutralRight();
            }
        }
    }


    void LaunchLeft()
    {
        audiosrc.BallLanding();
        balls[0].AddForce(transform.position.x,1000f, transform.position.z);
    }

    void LaunchRight()
    {
        audiosrc.BallLanding();
        balls[1].AddForce(transform.position.x, 1000f, transform.position.z);
    }
}
