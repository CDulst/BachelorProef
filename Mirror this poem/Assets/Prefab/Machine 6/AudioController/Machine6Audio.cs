using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine6Audio : MonoBehaviour
{

    public AudioSource audioSrc;
    public AudioClip Ballshooting;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public void BallShooting()
    {
        if(!audioSrc.isPlaying)
        {
            audioSrc.clip = Ballshooting;
            audioSrc.pitch = 1;
            audioSrc.Play();
        }

    }
}
