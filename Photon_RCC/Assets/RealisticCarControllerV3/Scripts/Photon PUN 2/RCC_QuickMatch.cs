using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class RCC_QuickMatch : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int maxPlayers = 4;

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }

    public  void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joind Random ROom succesfully : "); 
    }
}
