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
    private string _password;

    // Start is called before the first frame update
    
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roominfo)
    {
        RoomInfo = roominfo;
        
        _text.text = roominfo.Name;
       _password = (string)roominfo.CustomProperties["Password"];
        Debug.Log("Password setting in SetRoominfo is : " + _password);
    }

    public void OnClick_Button()
    {
       if(_password != null)
        {
            Debug.Log("This room is password protected !!!");
            Debug.Log("Pleae Enter Password" + _password +" to continue....");
        }
       else
        {
            Debug.Log("This  room is not password protected...");
            PhotonNetwork.JoinRoom(RoomInfo.Name);
        }
    }
}
