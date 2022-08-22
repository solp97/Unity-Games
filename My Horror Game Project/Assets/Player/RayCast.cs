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
            Debug.Log("������");
            if (selectItem.CompareTag("Key"))
            {
                Debug.Log("Ű ����");
                KeyInterpace.SetActive(true);
            }
            if (selectItem.CompareTag("Statue"))
            {
                Debug.Log("���� ����");
                StatueInterpace.SetActive(true);
            }
            if (selectItem.CompareTag("Board"))
            {
                Debug.Log("������ ����");
                BoardInterpace.SetActive(true);
            }

        }
    }
}
