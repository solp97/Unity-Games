using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button _joinButton;
    [SerializeField]
    private Text _joinButtonText;
    [SerializeField]
    private Text _myNickname;

    private InputField _myNicknameInputField;

    private void deactiveJoinButton(string message)
    {
        _joinButton.interactable = false;
        _joinButtonText.text = message;
    }
    private void activateJoinbutton()
    {
        _joinButton.interactable = true;
        _joinButtonText.text = "Join";
    }
    private void Awake()
    {

        PhotonNetwork.ConnectUsingSettings();

        deactiveJoinButton("���� ��");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���� ����");
        activateJoinbutton();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ConnectUsingSettings();
        base.OnDisconnected(cause);
        deactiveJoinButton("������ �õ�");
    }

    private static readonly RoomOptions RandomRoomOptions = new RoomOptions()
    {
        MaxPlayers = 20
    };


    private void OnClickedJoinButton()
    {
        if (_myNickname.text.Length == 0)
        {
            Debug.Log("���̳�� �̸�����");
        }
        else PhotonNetwork.JoinOrCreateRoom("Metaverse", RandomRoomOptions, default);

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("�� ����");

        PhotonNetwork.LoadLevel("main");
    }
}
