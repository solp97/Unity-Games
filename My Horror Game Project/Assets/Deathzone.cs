using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public PlayerHealth Killplayer;

    private void OnTriggerEnter(Collider other)
    {
        Killplayer.Die();
        Cursor.lockState = CursorLockMode.None;
    }
}
