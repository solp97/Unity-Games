using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject callDeathUi;
    public void Die()
    {
        callDeathUi.SetActive(true);
    }
}
