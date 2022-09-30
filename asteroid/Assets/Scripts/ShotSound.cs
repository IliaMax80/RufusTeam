using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Shot;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void audioPlay()
    {
            audioSource.PlayOneShot(Shot, 1F);
    }
}
