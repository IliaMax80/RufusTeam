using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public int IndexSide;
    public float LoopTime;
    private float time;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;
    private EnemyShotSide header;
    // Start is called before the first frame update
    private void Start()
    {
        header = GetComponentInParent<EnemyShotSide>();
    }

    // Update is called once per frame
    void Update()
    {
        if (header.fire)
        {
            if (time > LoopTime)
            {

                if (header.IndexSide == IndexSide)
                {
                    bullet = Instantiate(bulletPrefab);
                    bullet.transform.position = transform.position;
                    bullet.transform.LookAt(header.Player.transform);
                    bullet.transform.Rotate(0, -90, 0);
                }
                time = 0;
            }
            time += Time.deltaTime;
        }
        else
        {
            time = LoopTime + 1.0f; 
        }
    }
}
