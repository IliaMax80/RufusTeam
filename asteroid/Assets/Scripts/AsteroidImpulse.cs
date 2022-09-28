using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidImpulse : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, 100) * Time.fixedDeltaTime);
        //rb.MoveRotation(deltaRotation);
    }
}
