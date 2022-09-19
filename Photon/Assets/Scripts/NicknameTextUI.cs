using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class NicknameTextUI : MonoBehaviourPunCallbacks, 
    IPunObservable
{
    private TextMeshPro _ui;
    private int _clickCount = 0;
    private string _nickname;

    public string ClickCount;
    {
        get
        {
            return _clickCount;
        }

        set
        {
            
        }
    }

    public string Nickname
    {
        get
        {
            return _ui.text;
        }

        set
        {
            _ui.text = value;
        }
    }

    [PunRPC]
    public void SetNickname(string nickname)
    {
        Nickname = $"{nickname} : {_clickCount}";
    }

    void OnJoinedRoom()
    {

    }


    private void Awake()
    {
        _ui = 
    }

public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
{
    if(stream.IsWriting)
    {
        stream.SendNext(ClickCount);
    }
    else
    {
        ClickCount = (int)stream.ReceiveNext();
    }
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        photonView.RPC("SetNickname", newPlayer, Nickname);
    }
}
