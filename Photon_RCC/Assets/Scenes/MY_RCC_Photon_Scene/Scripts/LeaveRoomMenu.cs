using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviourPunCallbacks
{
    public static string room_name;
    public static string room_pass;
    public void OnClick_LeaveRoom()
    {
    //    PhotonNetwork.CurrentRoom.CustomProperties.Remove("secret");
    //    PhotonNetwork.CurrentRoom.RemovedFromList = true;
        PhotonNetwork.LeaveRoom(true);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left Room Succesffuly");
    }


}
