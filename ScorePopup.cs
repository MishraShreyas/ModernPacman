using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopup : MonoBehaviour
{
    public float timer=.5f;
    public GameObject scoreUI;
    public bool ghost=false;

    public int inc;
    public int startFontSize=100;

    Transform mid;

    float elapsedTime=0;
    TMP_Text txt;

    UIManager _uim;
    GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _uim = UIManager.instance;
        _gm = GameManager.instance;

        scoreUI = GameObject.Find("Canvas/Score");
        mid = _uim.pelletInfo.transform;
        txt = GetComponent<TMP_Text>();
        transform.position = mid.position;
        txt.text = "+"+inc.ToString();

        if (ghost) 
        {
            startFontSize*=2;
            txt.color = Color.red;
        }

        Destroy(gameObject, timer-.05f);
    }

    // Update is called once per frame
    void Update()
    {
        float perc = elapsedTime/timer;
        elapsedTime += Time.deltaTime;
        transform.position = Vector3.Lerp(mid.position, scoreUI.transform.position, perc);
        txt.fontSize = Mathf.Lerp(startFontSize, 20, perc);
    }

    private void OnDestroy() {
        _gm.score += inc;
    }
}
