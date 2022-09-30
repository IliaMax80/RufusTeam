using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCount : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Enemy> Enemies = new List<Enemy>();
    public int HP;
    private bool usedMethodEndOfGame = true;
    [SerializeField] private VictoryOrLose _endOfGame;
    [SerializeField] private Compass _compass;
    [SerializeField] private Text _textHP;
    [SerializeField] private Text _textEnemyCount;



    // Update is called once per frame
    void Update()
    {
        List<Vector3> vectors = new List<Vector3>();
        if(HP <= 0)
        {
            
            HP = 0;
            if (usedMethodEndOfGame)
            {
                _endOfGame.Losing();
                usedMethodEndOfGame = false;
            }

        }
        _textHP.text = "HP: " + HP.ToString();
        _textEnemyCount.text = "Enemies: " + Enemies.Count.ToString();
        if (Enemies.Count != 0)
        {


            foreach (Enemy enemy in Enemies)
            {
                vectors.Add(transform.position - enemy.gameObject.transform.position);
            }
            _compass.construction(vectors, transform.eulerAngles.y);
        }
        else
        {
            if (usedMethodEndOfGame)
            {
                _endOfGame.Victory();
                usedMethodEndOfGame = false;
            }
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AsteroidImpulse>() || collision.gameObject.GetComponent<Enemy>())
        {
            HP -= 5;
        }
        //Debug.Log(collision.gameObject.name);

    }
    private IEnumerator controllerAnimation()
    {
        yield return new WaitForSeconds(0.1f);
    }
    public void delete(Enemy enemyDelete)
    {
        List<Enemy> bufEnemies = new List<Enemy>();
        foreach (Enemy enemy in Enemies)
        {
            if (enemy != enemyDelete)
            {
                bufEnemies.Add(enemy);
            }
        }
        Enemies = bufEnemies;
    }

}
