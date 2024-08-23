using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //Universal Object Choices
    public GameObject SpawnerPre;
    public GameObject SpawnList;

    //Random Choices
    public int numberOfSpawns;

    //Existing Choices
    GameObject[] existing;
    public string WantedTag;

    [SerializeField] private float YHeight;

    // Start is called before the first frame update
    void Start()
    {
        EcoSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomSpawn()
    {
        System.Random r = new System.Random();
        int RandX;
        float NewX;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            RandX = r.Next(-60,numberOfSpawns);
            NewX = (float)RandX;

            //Spawning Player
            GameObject SpawnedAvatar = Instantiate(SpawnerPre, new Vector3(NewX, YHeight, 0.0f), Quaternion.identity);
        
            //Parenting an Object
            SpawnedAvatar.transform.parent = SpawnList.transform;
        }
    }

    private void EcoSpawn()
    {
        System.Random r = new System.Random();
        int Rand;
        float NewXZ;
        float RandScale;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            //Spawning the NPCs
            Rand = r.Next(-60,numberOfSpawns);
            NewXZ = (float)Rand;
            GameObject SpawnedAvatar = Instantiate(SpawnerPre, new Vector3(NewXZ, YHeight, NewXZ), Quaternion.identity);

            //Sets the object to a random scale.
            Rand = r.Next(0,5);
            RandScale = (float)Rand;
            Vector3 NpcScale = new Vector3(RandScale, RandScale, RandScale);
            SpawnedAvatar.transform.localScale = NpcScale;
        
            //Parenting an Object
            SpawnedAvatar.transform.parent = SpawnList.transform;
        }
    }

    private void SingleSpawn()
    {
        //Spawning Player
        GameObject SpawnedAvatar = Instantiate(SpawnerPre, new Vector3(0.0f, YHeight, 0.0f), Quaternion.identity);
        
        //Parenting an Object
        SpawnedAvatar.transform.parent = SpawnList.transform;
    }

    public void FindAndSpawn() 
    {   
        if (existing == null)
        {
            existing = GameObject.FindGameObjectsWithTag(WantedTag);
        }

        foreach (GameObject respawn in existing)
        {
            Instantiate(SpawnerPre, respawn.transform.position, respawn.transform.rotation);
            
            //Parenting an Object
            respawn.transform.parent = SpawnList.transform;
        }
    }
}
