using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private RocketMovement _flight;
    public float Rotation;
    private float _startZ;
    private float _stepRatete = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _startZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Rotation < 2)
            {
                Rotation += _stepRatete;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Rotation > -2)
            {
                Rotation -= _stepRatete;
            }


        }
        else
        {
            if (Rotation < 0 && !(Rotation == 0))
            {
                Rotation += _stepRatete;
            }
            else if (!(Rotation == 0))
            {
                Rotation -= _stepRatete;
            }
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _startZ - _flight.speed * 0.1f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Rotation);

        //Debug.Log(transform.eulerAngles);
    }
}
