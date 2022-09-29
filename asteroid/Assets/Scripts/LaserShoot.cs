using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    //[SerializeField] private GameObject laser;
    //[SerializeField] private GameObject GunPoint;
    public float LoopTime;
    public float size;
    private LineRenderer lazer;
    private bool updatePosition;
    private float _time;


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
        if (Input.GetKey(KeyCode.Space))
        {
            if (_time > LoopTime)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject.GetComponent<AsteroidImpulse>())
                    {
                        StartCoroutine(shot(hit.collider.gameObject, hit.point));
                    }
                }
                _time = 0;
            }
        }
        else
            _time += Time.deltaTime;


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
        target.GetComponent<Explosions>().Explode();
        Destroy(target);
        updatePosition = false;


    }
}
