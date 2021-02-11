using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public machine7 machine7Script;
    public PopUp popUP;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        GameObject machine7 = GameObject.Find("Machine7__V2");
        machine7Script = machine7.GetComponent<machine7>();
        popUP.CreatePopUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (machine7Script.canStartLeft)
        {
            popUP.deletePopUp();
            rb.AddRelativeTorque(0, -50, 0);
        }

        if (machine7Script.canStartRight)
        {
            popUP.deletePopUp();
            rb.AddRelativeTorque(0, +50, 0);
        }

    }
}
