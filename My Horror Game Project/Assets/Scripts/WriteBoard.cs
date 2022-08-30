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
            move.canMove = true;
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            light.intensity = 10;
            camera.rotateSpeed = 2f;
        }
    }
}
