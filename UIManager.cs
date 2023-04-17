using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject pelletInfo;
    public GameObject scorePopup;
    public GameObject pauseMenu;
    public GameObject player;
    public Text scoreText;
    public Text remainingText;

    public static UIManager instance;

    public bool displayText = false;

    public bool paused = false;

    [SerializeField]
    int total;

    TMP_Text textMesh;
    Mesh mesh;
    Vector3[] vertices;
    Color[] colors;
    float pelletInfoSize;

    bool started = false;

    GameManager _gm;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.instance;

        textMesh = pelletInfo.GetComponent<TMP_Text>();

        total = GameObject.FindGameObjectsWithTag("Point").Length;

        pelletInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Pellet info
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        colors = mesh.colors;

        if (displayText)
        {
            textMesh.fontSize += Time.deltaTime * 50;
            for (int i=0; i<vertices.Length; i++)
            {
                Vector3 offset = Wobble(Time.time + i);
                vertices[i] += offset;
            }
            mesh.vertices = vertices;
            textMesh.canvasRenderer.SetMesh(mesh);
        }

        //Score update
        remainingText.text = "collected: " + _gm.remains.ToString() + " of " + total.ToString();
        scoreText.text = "score: " + _gm.score.ToString();

        //Win screen
        if (!_gm.ended & _gm.remains == total)
        {
            _gm.ended = true;
            winCanvas.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<GhostCollission>().ending();
            AudioSource _music = _gm.transform.GetChild(0).GetComponent<AudioSource>();
            _music.Play();
        }

        //Pause
        if (!started)
        {
            started=true;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
        
    }

    public void togglePause()
    {
        if (paused){
            Time.timeScale = 1;
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
            player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = true;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
            player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        paused = !paused;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*1.8f));
    }

    public IEnumerator EatPellet()
    {
        pelletInfo.SetActive(true);
        pelletInfoSize = textMesh.fontSize;
        textMesh.fontSize /= 4;
        displayText = true;

        yield return new WaitForSeconds(.6f);

        pelletInfo.SetActive(false);
        textMesh.fontSize = pelletInfoSize;
        displayText = false;
    }
}
