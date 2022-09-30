using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    //[SerializeField] private GameObject laser;
    //[SerializeField] private GameObject GunPoint;
    public float LoopTime;
    public float Size;
    private LineRenderer _lazer;
    private bool _updatePosition;
    private float _time;


    // Start is called before the first frame update
    void Start()
    {
        _updatePosition = false;
        _lazer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Input.GetKey(KeyCode.Space))
        {
            if (_time > LoopTime)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f))
                {
                    //Debug.Log(hit.collider.gameObject);
                    //Debug.Log(hit.point);
                    if (hit.collider.gameObject.GetComponent<AsteroidImpulse>() || hit.collider.gameObject.GetComponent<EnemyMovement>())
                    {
                        StartCoroutine(shot(hit.collider.gameObject, hit.point));
                    }
                }
                _time = 0;
            }
            
        }
        _time += Time.deltaTime;

        if (_updatePosition)
        {
            _lazer.SetPosition(0, transform.position);
        }
    }
    private IEnumerator shot(GameObject target, Vector3 targetPosition)
    {
        GetComponentInChildren<ShotSound>().audioPlay();
        GetComponentInChildren<ShotSound>().audioPlay();
        _updatePosition = true;
        _lazer.positionCount = 2;
        _lazer.SetPosition(0, transform.position);
        _lazer.SetPosition(1, targetPosition);
        yield return new WaitForSeconds(0.1f);
        _lazer.positionCount = 0;
        if (target.GetComponent<AsteroidImpulse>())
        {
            DistroyAsteriod(target);
        }
        else
        {
            target.GetComponent<Enemy>().losingHP();
        }
        _updatePosition = false;
    }
    private void DistroyAsteriod(GameObject target)
    {
        target.GetComponent<Explosions>().Explode();
        Destroy(target);
    }

}
