using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteBoard : MonoBehaviour
{
    private void Update()
    {
        if(this.gameObject && Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
