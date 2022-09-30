using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryOrLose : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject LosingScreen;
    // Start is called before the first frame update
    void Update()
    {
        GetComponent<PlayerCount>();
    }

    // Update is called once per frame

    public void Victory()
    {
        VictoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Losing()
    {
        LosingScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
