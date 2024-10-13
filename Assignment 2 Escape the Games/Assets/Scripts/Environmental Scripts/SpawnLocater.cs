using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocater : MonoBehaviour
{
    public GameObject SpawnList;
    GameObject[] SpawnArray;
    public string WantedTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnArray == null)
        {
            SpawnArray = GameObject.FindGameObjectsWithTag(WantedTag);
        }

        foreach (GameObject lost in SpawnArray) 
        {           
            lost.transform.parent = SpawnList.transform;
        }
    }
}
