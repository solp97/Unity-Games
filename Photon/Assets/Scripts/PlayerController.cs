﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _rotationSpeed = 60f;




    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        

        if (photonView.IsMine)
        {
            Camera.main.transform.parent = transform;
            Camera.main.transform.localPosition = new Vector3(0f, 4f, -10f);
            Camera.main.transform.localRotation = Quaternion.identity;
        }
    }

    private void FixedUpdate()
    {
        if (false == photonView.IsMine)
        {
            return;
        }

        // 이동
        float inputForward = Input.GetAxis("Vertical");
        Vector3 deltaPosition = inputForward * _moveSpeed * Time.fixedDeltaTime * transform.forward;
        _rigidbody.MovePosition(_rigidbody.position + deltaPosition);

        // 회전
        float inputRight = Input.GetAxis("Horizontal");
        float deltaRotationY = inputRight * _rotationSpeed * Time.fixedDeltaTime;
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0f, deltaRotationY, 0f)); 
    }

}
