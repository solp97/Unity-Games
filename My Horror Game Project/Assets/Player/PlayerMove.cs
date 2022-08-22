using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController; 
    public float moveSpeed = 4f;
    public float jumpPower = 5f;

    public float groundDist = 0.2f;
    public LayerMask groundMask;
    public Transform groundCheck;

    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGround;



    void Update()
    {
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
}
