using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometr : MonoBehaviour
{
    [SerializeField] private Text text;
    private RocketMovement flight;

    private float _speed;

    void Start()
    {
        flight = GetComponent<RocketMovement>();
    }

    void FixedUpdate()
    {
        _speed = flight.speed*20.0f;
        text.text = "SPEED: " + ((int)_speed).ToString() + " km/h";
    }
}
