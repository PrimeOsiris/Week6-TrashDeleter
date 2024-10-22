using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpawn : MonoBehaviour
{
    //Avatar Choices
    public GameObject AvatarPre;
    public GameObject AvatarList;

    [SerializeField] private float YHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Spawning Player
        GameObject AvatarOne = Instantiate(AvatarPre, new Vector3(0.0f, YHeight, 0.0f), Quaternion.identity);
        
        //Parenting an Object
        AvatarOne.transform.parent = AvatarList.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
