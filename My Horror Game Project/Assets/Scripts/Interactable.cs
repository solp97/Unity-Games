using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public int ItemCode;
    public CameraRotate camera;
    public PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        ItemCode = Random.Range(0, 1000000);
    }

    public void CameraSpeed()
    {
        camera.rotateSpeed = 1.5f;
    }

    public void DontMove()
    {
        player.canMove = false;
    }
    public void Move()
    {
        player.canMove = true;
    }
}
