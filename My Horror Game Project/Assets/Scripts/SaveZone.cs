using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    public bool isPlayerInSaveZone = false;
    public GameObject CountUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) isPlayerInSaveZone = true;
        CountUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInSaveZone = false;
        CountUI.SetActive(false);
    }
}
