using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    public GameObject[] ToggleUIObjs;
    public CameraRotate cameraRotate;
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0f;
        cameraRotate.turnSpeed = 0f;
        for(int i = 0; i < ToggleUIObjs.Length; i++)
        {
            ToggleUIObjs[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (ToggleUIObjs[0] == false)
        {
            Time.timeScale = 1f;
            cameraRotate.turnSpeed = 4f;
        }
    }

}
