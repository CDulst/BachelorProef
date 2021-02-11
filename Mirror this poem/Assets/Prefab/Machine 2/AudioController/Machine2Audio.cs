using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine2Audio : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip projectorStart;
    public AudioClip projectorRunning;


    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    public void StartProjector()
    {
        audioSrc.clip = projectorStart;
        audioSrc.Play();
    }

    public void RunningProjector()
    {
        audioSrc.clip = projectorRunning;
        audioSrc.loop = true;
        audioSrc.Play();
    }



}
