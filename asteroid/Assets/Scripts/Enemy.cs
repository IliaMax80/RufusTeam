using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public bool fire;
    public int IndexSide;
    public GameObject Player;

    //forward - 0 
    // Update is called once per frame
    private void Start()
    {
        Player.GetComponent<PlayerCount>().Enemies.Add(this);
    }
    void Update()
    {
        if(HP <= 0)
        {
            GetComponent<Explosions>().Explode();
            Player.GetComponent<PlayerCount>().delete(this);
            Destroy(gameObject);
        }
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
    public void losingHP()
    {
        HP -= 1;
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

