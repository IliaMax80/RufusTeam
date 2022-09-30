using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public int IndexSide;
    public float LoopTime;
    private float time;
    [SerializeField] private GameObject _bulletPrefab;
    private GameObject _bullet;
    private Enemy _header;
    // Start is called before the first frame update
    private void Start()
    {
        _header = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_header.fire)
        {
            if (time > LoopTime)
            {

                if (_header.IndexSide == IndexSide)
                {
                    _bullet = Instantiate(_bulletPrefab);
                    _bullet.transform.position = transform.position;
                    _bullet.transform.LookAt(_header.Player.transform);
                    _bullet.transform.Rotate(0, -90, 0);
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
