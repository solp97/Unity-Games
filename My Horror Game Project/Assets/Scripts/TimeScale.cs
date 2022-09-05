using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public GameObject[] destroyThisObjects;
    public void Destroy()
    {
        for(int i = 0; i < destroyThisObjects.Length; i++)
        {
            Destroy(destroyThisObjects[i]);
        }
    }
    public void MouseLock()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
