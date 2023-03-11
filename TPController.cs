using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPController : MonoBehaviour
{
    public Transform tp;
    public Vector3 offset;
    public Vector3 rot;


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
        if (other.tag=="Player")
        {
            Debug.Log(other.transform.position.x);
            //other.transform.position.x = 2;// = new Vector3(0,0,0);//tp.position + offset;
        }
    }

    
}
