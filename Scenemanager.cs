using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public string map = "Game";

    public Scenemanager instance;
    private void Awake() {
        instance = this;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene(map);
    }

    public void doExitGame() {
        Application.Quit();
    }
}
