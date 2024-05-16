using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    public void OnClick_LeaveRoom()
    {
    //    PhotonNetwork.CurrentRoom.CustomProperties.Remove("secret");
    //    PhotonNetwork.CurrentRoom.RemovedFromList = true;
        PhotonNetwork.LeaveRoom(true);
    }
}
