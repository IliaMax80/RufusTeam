using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometr : MonoBehaviour
{
    [SerializeField] private Text text;
    private RocketMovement flight;

    private float Speed;

    void Start()
    {
        flight = GetComponent<RocketMovement>();
    }

    void FixedUpdate()
    {
        Speed = flight.speed*20.0f;
        text.text = "SPEED: " + ((int)Speed).ToString() + " km/h";
    }
}
