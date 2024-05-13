using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roominfo)
    {
        RoomInfo = roominfo;
        _text.text = roominfo.Name;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
