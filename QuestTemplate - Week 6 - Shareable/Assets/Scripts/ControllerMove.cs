using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    public OVRInput.RawButton button = OVRInput.RawButton.LThumbstickUp;

    public float speed = 10.0f;

    public GameObject pointer;

    public Vector3 constrainDirection = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(button)){
            this.transform.position += Time.deltaTime * speed * Vector3.ProjectOnPlane(pointer.transform.forward, constrainDirection);
        }
    }
}
