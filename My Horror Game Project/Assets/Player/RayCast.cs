using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public Text text;
    public GameObject textObject;
    UnityEvent interact;


    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit ,2,7))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                interact = hit.collider.GetComponent<Interactable>().onInteract;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.Invoke();
                }
                
            }

        }

    }

    void ChangeText()
    {
        text.text = "'F'를 눌러 상호작용";
        text.fontSize = 40;
    }
}
