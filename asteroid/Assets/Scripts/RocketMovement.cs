using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed;
    public float StepSpeed = 0.01f;
    public float StepRotate = 0.5f;
    public float MinSpeed = 0.01f;
    public float MaxSpeed = 5f;
    private float _speedRotateHorizontal = 0;
    private float _speedRotateVertical = 0;
    public float MaxSpeedRotate = 5;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = MinSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(transform.forward * speed);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        transform.Rotate(new Vector3(_speedRotateVertical * Time.deltaTime, 0, _speedRotateHorizontal * Time.deltaTime));

        if (Input.GetKey(KeyCode.LeftShift)) speed += StepSpeed;
        else if (Input.GetKey(KeyCode.LeftControl)) speed -= StepSpeed;
        if (speed < MinSpeed) speed = MinSpeed;
        if (speed > MaxSpeed) speed = MaxSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            _speedRotateVertical += StepRotate;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _speedRotateVertical -= StepRotate;
        }
        else
        {
            _speedRotateVertical /= 5;
        }
        if (_speedRotateVertical < -MaxSpeedRotate) _speedRotateVertical = -MaxSpeedRotate;
        if (_speedRotateVertical > MaxSpeedRotate) _speedRotateVertical = MaxSpeedRotate;

        if (Input.GetKey(KeyCode.A))
        {
            _speedRotateHorizontal += StepRotate;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _speedRotateHorizontal -= StepRotate;
        }
        else
        {
            _speedRotateHorizontal /= 5;
        }
        if (_speedRotateHorizontal < -MaxSpeedRotate) _speedRotateHorizontal = -MaxSpeedRotate;
        if (_speedRotateHorizontal > MaxSpeedRotate) _speedRotateHorizontal = MaxSpeedRotate;
        
        //Debug.Log(rb.GetPointVelocity(transform.eulerAngles));
    }
}
