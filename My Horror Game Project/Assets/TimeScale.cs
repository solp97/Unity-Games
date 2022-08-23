using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    CameraRotate cameraRotate;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        cameraRotate.turnSpeed = 0f;
        Time.timeScale = 0f;
    }

    public void unTimeScale()
    {
        cameraRotate.turnSpeed = 4f;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
