using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public float Scale;
    [SerializeField] private GameObject _sprateEnemyPrefab;
    private GameObject _cloneSprateEnemy;
    private List<GameObject> _sprites = new List<GameObject>();

    public void construction(List<Vector3> positions, float RotateY)
    {
        foreach (GameObject sprite in _sprites)
        {
            Destroy(sprite);
        }
        _sprites = new List<GameObject>();
        foreach (Vector3 position in positions)
        {
            transform.localEulerAngles = new Vector3(0, 0,  RotateY + 180);
            Vector3 CompassPosition = position / Scale;
            if (Vector2.Distance(new Vector2(CompassPosition.x, CompassPosition.z), new Vector2(0, 0)) > 100)
            {
                continue;
            }
            _cloneSprateEnemy = Instantiate(_sprateEnemyPrefab);
            _sprites.Add(_cloneSprateEnemy);
            _cloneSprateEnemy.transform.SetParent(transform);
            _cloneSprateEnemy.transform.localScale = new Vector3(1, 1, 1);
            _cloneSprateEnemy.transform.eulerAngles = transform.eulerAngles;
            _cloneSprateEnemy.transform.localPosition = new Vector3(CompassPosition.x, CompassPosition.z, 0);
            

        }
    }
}
