using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon;

public class PlayerController : MonoBehaviourPun

{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _rotateSpeed = 60f;

    private Rigidbody _rb;
    private Text _myNickname;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _myNickname = GetComponentInChildren<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(false == photonView.IsMine)
        {
            return;
        }

        float inputForward = Input.GetAxis("Vertical");
        Vector3 deltaPosition = inputForward * _moveSpeed * Time.fixedDeltaTime * _rb.transform.forward;
        _rb.MovePosition(_rb.position+deltaPosition);

        float inputRotate = Input.GetAxis("Horizontal");
        float deltaRotationY = inputRotate * _rotateSpeed * Time.fixedDeltaTime;
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(0f,deltaRotationY,0f));
    }
    [PunRPC]
    public void setNickname()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
