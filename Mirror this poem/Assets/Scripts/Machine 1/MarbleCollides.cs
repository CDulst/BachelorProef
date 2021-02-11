using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleCollides : MonoBehaviour
{
    public LampController lamp;
    public Machine1Animation machine;
    public string side;
    public Machine1Audio audio;


    public void Start()
    {
        lamp = FindObjectOfType<LampController>();
        machine = FindObjectOfType<Machine1Animation>();
        audio = FindObjectOfType<Machine1Audio>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Marble")
        {
            audio.PlaySwitch();
            machine.Hit(side,lamp);
        }
    }
}
