using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    public void NextScene(int _sceneNumber)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneNumber);

            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
