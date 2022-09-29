using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSide : MonoBehaviour
{
    public bool fire;
    public int IndexSide;
    public GameObject Player;

    //forward - 0 
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < 30)
        {
            Vector3 localPosition = transform.InverseTransformPoint(Player.transform.position);
            Vector3 vectorPlayer = localPosition / localPosition.magnitude;
            IndexSide = GetDirectionOnForward(vectorPlayer);
            fire = true;
        }
        else
        {
            fire = false;
        }

    }


    private int GetDirectionOnForward(Vector3 vector)
    {
        if ((Mathf.Abs(vector.x) > Mathf.Abs(vector.z)) && (Mathf.Abs(vector.x) > Mathf.Abs(vector.y)))
        {
            if (vector.x > 0) return 0;
            return 2;
        }
        else if ((Mathf.Abs(vector.y) > Mathf.Abs(vector.x)) && (Mathf.Abs(vector.y) > Mathf.Abs(vector.z)))
        {
            if (vector.y > 0) return 4;
            return 5;
        }
        else if ((Mathf.Abs(vector.z) > Mathf.Abs(vector.y)) && (Mathf.Abs(vector.z) > Mathf.Abs(vector.x)))
        {
            if (vector.z > 0) return 3;
            return 1;
        }

        return -1;
    }
}

