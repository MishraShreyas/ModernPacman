using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostCollission : MonoBehaviour
{
    private GameManager _gm;
    UIManager _uim;

    bool dead= false;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.instance;
        _uim = UIManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Camera.main.transform.Rotate(new Vector3(1,0,0) * Time.deltaTime * 10);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Ghost")) hitt(hit.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ghost")) hitt(other.gameObject);
    }

    void hitt(GameObject hit)
    {
        if (_gm.pelletMode!=0)
            {
                StartCoroutine(hit.GetComponent<GhostMover>().die());
                GameObject txt = Instantiate(_uim.scorePopup, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
                txt.GetComponent<ScorePopup>().inc = _gm.pelletMode;
                txt.GetComponent<ScorePopup>().ghost = true;
                _gm.pelletMode*=2;
                _gm.playAudio(1);
            } else
            {
                _gm.stopMusic();
                dead=true;
                ending();
            }
    }

    public void ending()
    {
        GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
        transform.GetChild(0).gameObject.GetComponent<AudioPlayer>().dead=true;
        transform.GetChild(0).gameObject.GetComponent<AudioSource>().Stop();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
