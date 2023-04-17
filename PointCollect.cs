using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointCollect : MonoBehaviour
{
    public GameObject scorePopup;

    GameManager _gm;
    UIManager _uim;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.instance;
        _uim = UIManager.instance;
        //_as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            _gm.playAudio(0);
            int inc = 50;
            if (gameObject.tag == "Point")
            {
                inc = 10;
                _gm.remains++;
            } else _gm.EatPellet();
            GameObject txt = Instantiate(_uim.scorePopup, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
            txt.GetComponent<ScorePopup>().inc = inc;
            Destroy(gameObject);
        }
    }
}
