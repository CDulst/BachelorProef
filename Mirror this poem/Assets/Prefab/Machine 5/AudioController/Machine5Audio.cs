using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine5Audio : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip Ballshooting;
    public AudioClip pullingDown;


    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void BallShooting()
    {
        audioSrc.clip = Ballshooting;
        audioSrc.pitch = 1;
        audioSrc.Play();
    }

    


}
