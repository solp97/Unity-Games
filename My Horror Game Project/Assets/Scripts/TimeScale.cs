using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public CameraRotate cameraRotate;
    public GameObject[] destroyThisObjects;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        cameraRotate.turnSpeed = 0f;
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraRotate.turnSpeed = 4f;
        Time.timeScale = 1f;
    }
    public void Destroy()
    {
        for(int i = 0; i < destroyThisObjects.Length; i++)
        {
            Destroy(destroyThisObjects[i]);
        }
    }
}