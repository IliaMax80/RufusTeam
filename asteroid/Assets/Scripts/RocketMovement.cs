using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed;
    public float stepSpeed = 0.01f;
    public float stepRotate = 0.5f;
    public float minSpeed = 0.01f;
    public float maxSpeed = 5f;
    private float _speedRotateHorizontal = 0;
    private float _speedRotateVertical = 0;
    public float maxSpeedRotate = 5;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = minSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(transform.forward * speed);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        transform.Rotate(new Vector3(_speedRotateVertical * Time.deltaTime, 0, _speedRotateHorizontal * Time.deltaTime));

        if (Input.GetKey(KeyCode.LeftShift)) speed += stepSpeed;
        else if (Input.GetKey(KeyCode.LeftControl)) speed -= stepSpeed;
        if (speed < minSpeed) speed = minSpeed;
        if (speed > maxSpeed) speed = maxSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            _speedRotateVertical += stepRotate;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _speedRotateVertical -= stepRotate;
        }
        else
        {
            _speedRotateVertical /= 5;
        }
        if (_speedRotateVertical < -maxSpeedRotate) _speedRotateVertical = -maxSpeedRotate;
        if (_speedRotateVertical > maxSpeedRotate) _speedRotateVertical = maxSpeedRotate;

        if (Input.GetKey(KeyCode.A))
        {
            _speedRotateHorizontal += stepRotate;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _speedRotateHorizontal -= stepRotate;
        }
        else
        {
            _speedRotateHorizontal /= 5;
        }
        if (_speedRotateHorizontal < -maxSpeedRotate) _speedRotateHorizontal = -maxSpeedRotate;
        if (_speedRotateHorizontal > maxSpeedRotate) _speedRotateHorizontal = maxSpeedRotate;
        
        //Debug.Log(rb.GetPointVelocity(transform.eulerAngles));
    }
}
