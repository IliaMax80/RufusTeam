using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometr : MonoBehaviour
{
    [SerializeField] private Text _text;
    private RocketMovement _flight;

    private float _speed;

    void Start()
    {
        _flight = GetComponent<RocketMovement>();
    }

    void FixedUpdate()
    {
        _speed = _flight.speed*20.0f;
        _text.text = "SPEED: " + ((int)_speed).ToString() + " km/h";
    }
}
