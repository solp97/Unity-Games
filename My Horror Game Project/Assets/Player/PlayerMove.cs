using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public float stamina;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump;
    bool readyToRun;
    public bool isMove = false;
    public bool canMove = true;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    StaminaController staminaController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        staminaController = GetComponent<StaminaController>();
        rb.freezeRotation = true;

        readyToJump = true;
        readyToRun = true;
    }

    private void Update()
    {
        if(canMove)
        {
            // ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

            MyInput();
            SpeedControl();

            // handle drag
            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }

    }

    private void FixedUpdate()
    {
        if(canMove) MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKey(runKey) && isMove && readyToRun)
        {
            moveSpeed = 10f;
            staminaController.StaminaDown();

        }
        else
        {
            staminaController.StaminaUp();
            moveSpeed = 5f;
        }
        if(stamina <= 0)
        {
            stamina = 0;
            readyToRun = false;
        }
        else if (stamina >= 20)
        {
            readyToRun = true;
        }
        else if(stamina >= 100)
        {
            stamina = 100;
        }

        if(horizontalInput < 0 || horizontalInput > 0 || verticalInput < 0 || verticalInput > 0)
        {
            isMove = true;
        }

    }

    private void MovePlayer()
    {
        
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}

