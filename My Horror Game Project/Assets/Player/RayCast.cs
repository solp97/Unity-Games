using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public Text text;
    public GameObject textObject;
    public CameraRotate camera;
    UnityEvent interact;
    public LayerMask[] layerMask;
    public Interactable interactable;



    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, layerMask[0]))
        {
            text.text = "'E'를 눌러 획득";
            textObject.SetActive(true);
            if (hit.collider.GetComponent<Interactable>() != false)
            {
               if(interactable == null || interactable.ItemCode != hit.collider.GetComponent<Interactable>().ItemCode)
                {

                interact = hit.collider.GetComponent<Interactable>().onInteract;

                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.Invoke();
                }

            }

        }
        else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4, layerMask[1]))
        {
            text.text = "'F'를 눌러 상호작용";
            text.fontSize = 40;
            textObject.SetActive(true);
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                interact = hit.collider.GetComponent<Interactable>().onInteract;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Cursor.lockState = CursorLockMode.None;
                interact.Invoke();
                }

            }

        }
        else textObject.SetActive(false);
    }
}
