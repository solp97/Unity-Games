using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController; 
    public float moveSpeed = 4f;
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



    void Update()
    {
        Run();
        
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
        if(canRun) moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : 4f;

        stamina += Input.GetKey(KeyCode.LeftShift) ? -0.15f : 0.03f;

        if(stamina <= 0)
        {
            stamina = 0;
            drainedCount++;
            canRun = false;
        }
        else if(stamina >=100f)
        {
            stamina = 100f;
            canRun = true;
        }

        switch (drainedCount)
        {
            case 0:
                runSpeed = 10;
                break;
            case 1:
                runSpeed = 7;
                break;
            case 2:
                runSpeed = 4;
                break;
        }
    }
}
