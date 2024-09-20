using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    [Tooltip("Controller Input used for movement")]
    public OVRInput.RawButton moveButton = OVRInput.RawButton.LThumbstickUp;
    [Tooltip("Movement Speed")]
    public float moveSpeed = 10f;
    [Tooltip("Object used to determine direction of movement")]
    public GameObject pointer;
    [Tooltip("Constraint used to filter movement. The normal of the plane the movement is projected onto.")]
    public Vector3 constrainDirection = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(moveButton)){
            this.transform.position += Time.fixedDeltaTime * moveSpeed * Vector3.ProjectOnPlane(pointer.transform.forward, constrainDirection);
        }
    }
}
