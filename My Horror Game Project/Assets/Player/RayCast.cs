using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject KeyInterpace;
    public GameObject StatueInterpace;
    public GameObject BoardInterpace;


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectItem = hit.transform;
            Debug.Log("감지중");
            if (selectItem.CompareTag("Key"))
            {
                Debug.Log("키 감지");
                KeyInterpace.SetActive(true);
            }
            if (selectItem.CompareTag("Statue"))
            {
                Debug.Log("동상 감지");
                StatueInterpace.SetActive(true);
            }
            if (selectItem.CompareTag("Board"))
            {
                Debug.Log("보드판 감지");
                BoardInterpace.SetActive(true);
            }

        }
    }
}
