using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject callDeathUi;
    public int playerHealth;
    private void Start()
    {
        playerHealth = 2;
    }

    public void Die()
    {
        callDeathUi.SetActive(true);
    }
}
