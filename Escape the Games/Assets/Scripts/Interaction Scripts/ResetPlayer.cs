using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    [Tooltip("Player spawn point")]
    public Vector3 spawnPoint;

    [Tooltip("The Player")]
    public GameObject Player;

    [Tooltip("Player Rigidbody")]
    public Rigidbody rb;

    [Tooltip("The reset button.")]
    public OVRInput.RawButton reset = OVRInput.RawButton.Y;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(reset)){
            Player.transform.position = spawnPoint;
            Player.transform.rotation = new Quaternion(0,0,0,0);
            rb.velocity = new UnityEngine.Vector3(0, 0, 0);
        }
    }
}
