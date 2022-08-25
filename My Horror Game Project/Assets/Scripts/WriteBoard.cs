using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteBoard : MonoBehaviour
{
    public CameraRotate camera;
    private void Update()
    {
        if(this.gameObject && Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            camera.turnSpeed = 4f;
        }
    }
}