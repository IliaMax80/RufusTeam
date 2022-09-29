using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    public float SpeedRotate;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        transform.Rotate(new Vector3(0, SpeedRotate * Time.deltaTime, 0));
    }
}
