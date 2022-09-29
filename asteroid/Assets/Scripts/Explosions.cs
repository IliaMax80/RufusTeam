using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

    }
}
