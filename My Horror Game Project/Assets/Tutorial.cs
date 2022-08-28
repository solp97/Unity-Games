using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject UIText;
    [SerializeField] GameObject ChekPoint;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(UIText);
        Destroy(ChekPoint);
    }
}
