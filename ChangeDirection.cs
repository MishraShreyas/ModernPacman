using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public bool[] directions;

    private int[] opp = {2, 3, 0, 1};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Ghost") return;

        int x = Random.Range(0, 4);
        while (!directions[x] || other.GetComponent<GhostMover>().drxn==opp[x]) x = Random.Range(0, 4);
        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x, 90*x, other.transform.eulerAngles.z);
        other.transform.position=new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
        other.GetComponent<GhostMover>().drxn=x;
    }
}
