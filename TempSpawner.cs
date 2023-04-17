using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpawner : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        foreach (Transform child in transform)
        {
            Instantiate(prefab, new Vector3 (child.position.x, 80, child.position.z), Quaternion.identity, transform);
            yield return new WaitForSeconds(1f);
        }
    }
}
