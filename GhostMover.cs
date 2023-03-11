using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMover : MonoBehaviour
{
    public float speed=3f;
    public int drxn=0;

    private Vector3[] _drxn = {Vector3.forward, Vector3.right, Vector3.back, Vector3.left};
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_drxn[0] * Time.deltaTime * speed);
    }
}
