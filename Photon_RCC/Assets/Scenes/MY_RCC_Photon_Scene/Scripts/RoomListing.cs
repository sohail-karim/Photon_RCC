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
    
    public GameObject PasswordPanel;
    
     public GameObject _lockImage;

    public delegate void OnRoomButtonClicked();
    public static event OnRoomButtonClicked _OnRoomButtonClicked;

    // Start is called before the first frame update
    private void Start()
    {
       
    }
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roominfo)
    {
        RoomInfo = roominfo;
        
        _text.text = roominfo.Name;
       _password = (string)roominfo.CustomProperties["Password"];
       
        gameObject.name = roominfo.Name;
        if (_password != null)
            _lockImage.SetActive(true);
            Debug.Log("Password setting in SetRoominfo is : " + _password);
    }

    public void OnClick_Button()
    {
        database.roomselected = gameObject.name;

        Debug.Log("Selected Room Name  is : " +  database.roomselected);
        string key = gameObject.name;
        if(database.roomslist.TryGetValue(key, out string value))
        {
            Debug.Log("Selected Room Password is : " + value);
            _OnRoomButtonClicked.Invoke();
        }
        else
        {
            Debug.Log("No Password Found for this Room : ");
            PhotonNetwork.JoinRoom(key); 
        }
 //       PlayerPrefs.SetString("Password", _password);
 //       PlayerPrefs.SetString("RoomName", gameObject.name);
 //
 //     if (_password != null)
 //     {
 //         _OnRoomButtonClicked.Invoke();
 //      //   GameObject gameObject = GameObject.FindGameObjectWithTag("PassPanel");
 //        // Instantiate(PasswordPanel);
 //         Debug.Log("This room is password protected !!!");
 //         Debug.Log("Pleae Enter Password" + _password +" to continue....");
 //     }
 //    else
 //     {
 //         Debug.Log("This  room is not password protected...");
 //         PhotonNetwork.JoinRoom(RoomInfo.Name);
 //     }
    }

   
}
