using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour
{
    public GameObject[] ToggleUIObjs;
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
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
        }
    }

}
