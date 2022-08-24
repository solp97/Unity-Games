using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public Transform player;
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.None;
            turnSpeed = 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.LeftAlt) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            turnSpeed = 4f;
        }
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * turnSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
