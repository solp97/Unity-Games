using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour
{
    public GameObject[] ToggleUIObjs;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("마우스 보임");
            for (int i = 0; i < ToggleUIObjs.Length; i++)
            {
                ToggleUIObjs[i].SetActive(true);
            }
            Time.timeScale = 0.2f;
        }

    }
}
