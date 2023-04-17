using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMover : MonoBehaviour
{
    public float speed=3f;
    public int drxn=0;
    public bool delay = true;
    public float delayTime = 3f;

    private Vector3[] _drxn = {Vector3.forward, Vector3.right, Vector3.back, Vector3.left};

    private GameManager _gm; 
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.instance;

        if (delay) StartCoroutine(lateStart());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_drxn[0] * Time.deltaTime * speed);
    }

    public IEnumerator die()
    {
        float currSpeed = speed;
        speed=0;
        transform.localEulerAngles = Vector3.zero;
        transform.position = new Vector3(0, transform.position.y, 0);
        drxn=0;

        yield return new WaitForSeconds(.1f);
        speed = currSpeed;
    }

    public IEnumerator lateStart()
    {
        float currSpeed = speed;
        speed=0;
        drxn=0;

        yield return new WaitForSeconds(delayTime);
        transform.localEulerAngles = Vector3.zero;
        transform.position = new Vector3(0, transform.position.y, 0);
        speed = currSpeed;
    }
}
