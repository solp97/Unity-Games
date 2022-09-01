using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteBoard : MonoBehaviour
{
    public CameraRotate camera;
    public Light light;
    public PlayerMove move;
    private void Update()
    {
        if(this.gameObject && Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            light.intensity = 10;
            move.canMove = true;
            camera.rotateSpeed = 1.5f;
        }
    }
}
