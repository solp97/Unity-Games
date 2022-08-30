using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteBoard : MonoBehaviour
{
    public CameraRotate camera;
    public Light light;
    private void Update()
    {
        if(this.gameObject && Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            light.intensity = 10;
        }
    }
}
