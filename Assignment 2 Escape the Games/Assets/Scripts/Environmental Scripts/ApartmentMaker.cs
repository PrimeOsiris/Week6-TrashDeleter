using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartmentMaker : MonoBehaviour
{
    public GameObject[] roomPrefabs;
    public float roomSize; //Size of each room
    public int depth; //How many apartments behind the front of the building
    public int adjacent; //How many apartments wide the building is
    public int stories; //How many apartments high the building is


    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < adjacent; x++){
            for (int z = 0; z < depth; z++){
                for (int y = 0; y < stories; y++){
                    GameObject roomPrefab = roomPrefabs[Random.Range(0,roomPrefabs.Length)]; //Randomly selects an apartment blueprint

                    Vector3 position = new Vector3(x*roomSize, y*roomSize/2, z*roomSize); //Determines the position of the apartments

                    Instantiate(roomPrefab, position, Quaternion.identity); //Spawns the apartments
                }
            }
        }
    }
}
