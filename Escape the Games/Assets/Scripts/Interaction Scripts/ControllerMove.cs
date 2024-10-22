using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    public GameObject Player;

    [Header("Horizontal Movement")]
    [Tooltip("Controller Input used for movement")]
    public OVRInput.RawButton moveButton = OVRInput.RawButton.RIndexTrigger;
    [Tooltip("Movement Speed")]
    public float moveSpeed = 10f;
    [Tooltip("Object used to determine direction of movement")]
    public GameObject pointer;
    [Tooltip("Constraint used to filter movement. The normal of the plane the movement is projected onto.")]
    public Vector3 constrainDirection = new Vector3(0,1,0);

    [Header("Rotation")]
    [Tooltip("The inputs to turn you left")]
    public OVRInput.RawButton LLeftRotation = OVRInput.RawButton.LThumbstickLeft;
    public OVRInput.RawButton RLeftRotation = OVRInput.RawButton.RThumbstickLeft;
    [Tooltip("The inputs to turn you right")]
    public OVRInput.RawButton LRightRotation = OVRInput.RawButton.LThumbstickRight;
    public OVRInput.RawButton RRightRotation = OVRInput.RawButton.RThumbstickRight;
    float yRotation = 0;
    float turnLeft = 0;
    float turnRight = 0;

    [Header("Jumping")]
    [Tooltip("The force/height you want to jump")]
    public float JumpForce;
    bool readyToJump;
    public Rigidbody rb;
    [Tooltip("Controller Input used for jumping")]
    public OVRInput.RawButton jumpButton = OVRInput.RawButton.A;
    public LayerMask WhereGround;
    bool grounded;
    

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(moveButton)){
            this.transform.position += Time.fixedDeltaTime * moveSpeed * Vector3.ProjectOnPlane(pointer.transform.forward, constrainDirection);
        }
        grounded = Physics.Raycast(transform.position, UnityEngine.Vector3.down, 3f, WhereGround);
        if  (grounded)
        {
            ResetJump();
        }
        if (readyToJump = true && OVRInput.Get(jumpButton)){
            Jump();
        }
        if (OVRInput.Get(LLeftRotation) || OVRInput.Get(RLeftRotation))
        {
            yRotation = Player.transform.eulerAngles.y;
            turnLeft -= .01f;
            if(turnLeft <= -0.5)
            {
                Debug.Log("Turn Left");
                Player.transform.Rotate(0, yRotation - turnLeft, 0);
                turnLeft += turnLeft;
            }
        }
        if (OVRInput.Get(LRightRotation) || OVRInput.Get(RRightRotation))
        {
            yRotation = Player.transform.eulerAngles.y;
            turnRight += .01f;
            if(turnRight >= 0.5)
            {
                Debug.Log("Turn Right");
                Player.transform.Rotate(0, yRotation + turnRight, 0);
                turnRight -= turnRight;
            }
        }
    }

    private void Jump()
    {
        //reset Y speed for consistent jump height
        rb.velocity = new UnityEngine.Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
    private void ResetJump(){
        readyToJump = true;
    }
}
