using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    //[SerializeField] private GameObject laser;
    //[SerializeField] private GameObject GunPoint;
    public float size;
    private LineRenderer lazer;
    private bool updatePosition;


    // Start is called before the first frame update
    void Start()
    {
        updatePosition = false;
        lazer = GetComponent<LineRenderer>();

    }

// Update is called once per frame
void Update()
    { 
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.gameObject.GetComponent<AsteroidImpulse>())
                {
                    StartCoroutine(shot(hit.collider.gameObject, hit.point));
                    
                }
            }
        }
        if (updatePosition)
        {
            lazer.SetPosition(0, transform.position);
        }
    }
    private IEnumerator shot(GameObject target, Vector3 targetPosition)
    {
        GetComponentInChildren<ShotSound>().audioPlay();
        GetComponentInChildren<ShotSound>().audioPlay();
        updatePosition = true;
        lazer.positionCount = 2;
        lazer.SetPosition(0, transform.position);
        lazer.SetPosition(1, targetPosition);
        yield return new WaitForSeconds(0.1f);
        lazer.positionCount = 0;
        Destroy(target);
        updatePosition = false;


    }
}
