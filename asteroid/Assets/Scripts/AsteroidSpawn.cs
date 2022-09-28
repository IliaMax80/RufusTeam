using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public int maxRange = 50;
    public int minRange = -50;
    public Vector2 ScaleRange;
    [SerializeField] private List<GameObject> _prefabAsteroids = new List<GameObject>();
    private GameObject _clone;
    // Start is called before the first frame update
    void Start()
    {
        float _scale;
        for (int i = 0; i < 200; i++)
        {
            _clone = Instantiate(_prefabAsteroids[Random.Range(0, _prefabAsteroids.Count)]);
            _clone.transform.position = new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), Random.Range(minRange, maxRange));
            _scale = Random.Range(ScaleRange.x, ScaleRange.y);
            _clone.transform.localScale = new Vector3(_scale, _scale, _scale);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
