using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController; 
    private StaminaController staminaController;

    public float moveSpeed = 4f;
    public bool running;
    public float runSpeed = 10f;
    public float jumpPower = 5f;
    public float stamina = 100f;

    public float groundDist = 0.2f;
    public LayerMask groundMask;
    public Transform groundCheck;

    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGround;
    [SerializeField] private int drainedCount;
    [SerializeField] private bool canRun = true;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        staminaController = GetComponent<StaminaController>();
    }

    void Update()
    {
        Run();
        staminaController.StaminaUp();
        if(stamina > 10 )
        {
            canRun = true;
        }


        isGround = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGround )
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    void Run()
    {
        moveSpeed = Input.GetKey(KeyCode.LeftShift)&& canRun ? runSpeed : 4f;


        if(Input.GetKey(KeyCode.LeftShift)&& moveSpeed > 4)
        {
            staminaController.StaminaDown();
            running = true;
        }
        if(stamina <= 0)
        {
            stamina = 0;
            drainedCount++;
            canRun = false;
        }
        else if(stamina >=100f)
        {
            stamina = 100f;
        }
    }
}
