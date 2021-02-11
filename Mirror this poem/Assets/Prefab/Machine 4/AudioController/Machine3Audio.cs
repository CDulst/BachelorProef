using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine3Audio : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip ballLanding;


    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void BallLanding()
    {
        audioSrc.clip = ballLanding;
        audioSrc.Play();
    }


   


}
