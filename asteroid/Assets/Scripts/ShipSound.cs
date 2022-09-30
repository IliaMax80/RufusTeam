using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSound : MonoBehaviour
{
    private AudioSource _audioSource;
    public float MinPitch = 1f;
    public float MaxPitch = 2f;
    private float _pitchFromCar;
    public float MaxSpeed;
    public float minSpeed;
    private RocketMovement _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = GetComponent<RocketMovement>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.pitch = MinPitch;
    }

    // Update is called once per frame
    void Update()
    {
        _pitchFromCar = _speed.speed * 0.08f;
        _audioSource.pitch = _pitchFromCar;
    }

}
