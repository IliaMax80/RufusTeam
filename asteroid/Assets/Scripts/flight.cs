using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flight : MonoBehaviour
{
    public float speed;
    public float stepSpeed = 0.01f;
    private float stepRotate = 0.5f;
    private float speedRotateAD = 0;
    private float speedRotateWS = 0;
    private float maxSpeedRotate = 5;
    public float minSpeed = 0.01f;
    public float maxSpeed = 5f;
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
        //rb.AddForce(transform.forward * speed);
        transform.Translate(new Vector3(0, 0, speed));
        transform.Rotate(new Vector3(speedRotateWS, 0, speedRotateAD));

        if (Input.GetKey(KeyCode.LeftShift)) speed += stepSpeed;
        else if (Input.GetKey(KeyCode.LeftControl)) speed -= stepSpeed;
        if (speed < minSpeed) speed = minSpeed;
        if (speed > maxSpeed) speed = maxSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            speedRotateWS += stepRotate;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speedRotateWS -= stepRotate;
        }
        else
        {
            speedRotateWS /= 5;
        }
        if (speedRotateWS < -maxSpeedRotate) speedRotateWS = -maxSpeedRotate;
        if (speedRotateWS > maxSpeedRotate) speedRotateWS = maxSpeedRotate;

        if (Input.GetKey(KeyCode.A))
        {
            speedRotateAD += stepRotate;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedRotateAD -= stepRotate;
        }
        else
        {
            speedRotateAD /= 5;
        }
        if (speedRotateAD < -maxSpeedRotate) speedRotateAD = -maxSpeedRotate;
        if (speedRotateAD > maxSpeedRotate) speedRotateAD = maxSpeedRotate;
        
        Debug.Log(rb.GetPointVelocity(transform.eulerAngles));
    }
}
