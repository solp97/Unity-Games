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

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    bool readyToJump;

    bool readyToRun;
    public bool isMove = false;
    public bool canMove = true;
    public float swingSpeed;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode grapKey = KeyCode.Mouse0;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsJumpable;
    bool grounded;

    [Header("Camera Effects")]
    public Camera cam;
    public float grappleFov = 95f;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;



    public enum MovementState
    {
        grappling,
        swinging
    }

    public bool freeze;

    public bool activeGrapple;
    public bool swinging;
    public MovementState state;

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

    private void StateHandler()
    {
        // Mode - Grappling
        if (activeGrapple)
        {
            state = MovementState.grappling;
            moveSpeed = sprintSpeed;
        }

        // Mode - Swinging
        else if (swinging)
        {
            state = MovementState.swinging;
            moveSpeed = swingSpeed;
        }
    }

        private void Update()
    {
        if(canMove)
        {
            // ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsJumpable);

            MyInput();
            StateHandler();

            // handle drag
            if (grounded && !activeGrapple)
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

        if (Input.GetKey(jumpKey) && readyToJump && grounded && stamina > 30)
        {
            readyToJump = false;
           
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKey(runKey) && isMove && readyToRun)
        {
            moveSpeed = 6f;
            staminaController.StaminaDown();

        }
        else
        {
            staminaController.StaminaUp();
            moveSpeed = 3f;
        }
        if(stamina <= 0)
        {
            stamina = 0;
            readyToRun = false;
        }
        if (stamina >= 20)
        {
            readyToRun = true;
        }
        if(stamina >= 100)
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

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        staminaController.JumpStaminaDown();
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private bool enableMovementOnNextTouch;
    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activeGrapple = true;
        Invoke(nameof(SetVelocity), 0.1f);

        Invoke(nameof(ResetRestrictions), 3f);
    }

    private Vector3 velocityToSet;
    private void SetVelocity()
    {
        enableMovementOnNextTouch = true;
        rb.velocity = velocityToSet;
    }

    public void ResetRestrictions()
    {
        activeGrapple = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (enableMovementOnNextTouch)
        {
            enableMovementOnNextTouch = false;
            ResetRestrictions();
        }
    }
}

