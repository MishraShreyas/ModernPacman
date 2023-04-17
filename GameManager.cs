using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int remains = 0;
    public float pelletTime = 30f;
    public int pelletMode = 0;

    public GameObject[] ghosts;
    public bool gst = true;

    [SerializeField]
    private float cd=0;
    private bool _cd=false;

    public AudioClip eatAudio;
    public AudioClip GhostDeathAudio;
    public AudioClip PacDeathAudio;

    public bool ended=false;

    private AudioSource _music;
    private AudioSource _as;

    public static GameManager instance;

    private UIManager _uim;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _uim = UIManager.instance;

        _as = GetComponent<AudioSource>();
        _music = transform.GetChild(0).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cd) cd -= Time.deltaTime;

        if (_cd && cd<=0) StopPellet();
    }

    public void EatPellet()
    {
        _music.Play();
        StartCoroutine(_uim.EatPellet());
        foreach (GameObject x in ghosts)
        {
            if (gst)
            {
                x.transform.GetChild(0).gameObject.SetActive(true);
                x.transform.GetChild(1).gameObject.SetActive(false);
            }else 
            {
                x.GetComponent<Animator>().SetBool("Pellet", true);
            }
        }
        pelletMode = 200;
        cd = pelletTime;
        _cd = true;    
    }

    public void StopPellet()
    {
        _cd = false;
        _music.Stop();
        foreach (GameObject x in ghosts)
        {
            if (gst)
            {
                x.transform.GetChild(0).gameObject.SetActive(false);
                x.transform.GetChild(1).gameObject.SetActive(true);
            }
            else 
            {
                x.GetComponent<Animator>().SetBool("Pellet", false);
            }
        }
        pelletMode = 0;
        cd = 0;
    }

    public void playAudio(int x)
    {
        if (x==0) _as.PlayOneShot(eatAudio);
        else _as.PlayOneShot(GhostDeathAudio);
    }

    public void stopMusic()
    {
        _uim.loseCanvas.SetActive(true);
        _as.PlayOneShot(PacDeathAudio);
        _music.Stop();
    }
}
