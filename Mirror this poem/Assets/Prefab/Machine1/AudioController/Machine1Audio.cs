using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine1Audio : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip LightSwitch;


    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    public void PlaySwitch()
    {
        audioSrc.clip = LightSwitch;
        audioSrc.Play();
    }


 
}
