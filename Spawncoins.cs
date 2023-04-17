using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawncoins : MonoBehaviour
{
    public GameObject CoinPrefab;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        foreach (Transform child in transform)
        {
            Instantiate(CoinPrefab, new Vector3(child.position.x, 3, child.position.z), Quaternion.identity, parent);
        }
    }
}
