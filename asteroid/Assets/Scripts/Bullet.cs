using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerCount>())
        {
            collision.gameObject.GetComponent<PlayerCount>().HP -= 1;
            Destroy(gameObject);
        }
    }
}
