using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public float groundDrag;

    public float JumpForce;
    public float ShonenCooldown;
    public float airMulti;
    bool readyToJump;

    [Header("KeyBinds")]
    public KeyCode jumpkey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask WhereGround;
    bool grounded;

    public Transform orientation;

    float HorizonInput;
    float VerticaInput;

    UnityEngine.Vector3 Direction;

    Rigidbody rb;

    private void PlayerInput()
    {
        HorizonInput = Input.GetAxisRaw("Horizontal");
        VerticaInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpkey) && readyToJump && grounded){
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), ShonenCooldown);
        }
    }

    private void PlayerMove()
    {
        Direction = orientation.forward * VerticaInput + orientation.right * HorizonInput;

        if(grounded){
            rb.AddForce(Direction.normalized * MoveSpeed * 10f, ForceMode.Force);
        }

        else if(!grounded){
            rb.AddForce(Direction.normalized * MoveSpeed * 10f * airMulti, ForceMode.Force);
        }    
    }

    private void SpeedControl()
    {
        UnityEngine.Vector3 FlatVel = new UnityEngine.Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        if(FlatVel.magnitude > MoveSpeed){
            UnityEngine.Vector3 limitVel = FlatVel.normalized * MoveSpeed;
            rb.velocity = new UnityEngine.Vector3(limitVel.x, rb.velocity.y, limitVel.z);
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
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ResetJump();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, UnityEngine.Vector3.down, playerHeight * 0.5f + 0.2f, WhereGround);

        PlayerInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else {
            rb.drag = 0;
        }
    }

    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        PlayerMove();
    }
}
