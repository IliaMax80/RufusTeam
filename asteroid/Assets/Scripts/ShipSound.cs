using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSound : MonoBehaviour
{
    AudioSource audioSource;
    public float minPitch = 1f;
    public float maxPitch = 2f;
    private float pitchFromCar;
    public float maxSpeed;
    public float minSpeed;
    private RocketMovement speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<RocketMovement>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = speed.speed * 0.08f;
        audioSource.pitch = pitchFromCar;
    }

}
