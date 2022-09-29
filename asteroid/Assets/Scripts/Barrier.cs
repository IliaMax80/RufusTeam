using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {

        GameObject Object = other.gameObject;
        if (Object.GetComponent<Bullet>())
        {
            Destroy(Object);
        }
    }

}
