using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChange : MonoBehaviour
{
    public GameObject pacmanBG;
    public GameObject bennettBG;

    public Text themeName;

    private int theme = 0;

    public GameObject scm;
    private Scenemanager _scm;

    private void Start() {
        _scm = scm.GetComponent<Scenemanager>();
    }

    public void toggle()
    {
        switch (theme)
        {
            case 0:
                theme=1;
                pacmanBG.SetActive(false);
                bennettBG.SetActive(true);
                themeName.text = "map: Bennett";
                _scm.map = "Bennett";
                break;
            case 1:
                theme=0;
                pacmanBG.SetActive(true);
                bennettBG.SetActive(false);
                themeName.text = "map: OG Pacman";
                _scm.map = "Game";
                break;
            default:
                theme=0;
                pacmanBG.SetActive(true);
                bennettBG.SetActive(false);
                break;
        }
    }
}
