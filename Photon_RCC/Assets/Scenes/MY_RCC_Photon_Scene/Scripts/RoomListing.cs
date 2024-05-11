using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    
    public void SetRoomInfo(RoomInfo roominfo)
    {
        _text.text = roominfo.MaxPlayers + ", " + roominfo.Name;
    }
}
