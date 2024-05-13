using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
using System;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
    /// </summary>
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    #region Private Serializable Fields

    #endregion
    #region Public Fields
    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject Browse_Room_Panels;

    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject Create_Room_Panel;
    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    public  GameObject browse_Players_Panel;
    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject controlPanel;
    [Tooltip("RoomName to be created!")]
    [SerializeField]
    private TMP_InputField _roomName;
    [SerializeField]
    private GameObject Modes_panel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
   
    #endregion
    #region Private Fields
    /// <summary>
    /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
    /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
    /// Typically this is used for the OnConnectedToMaster() callback.
    /// </summary>
    bool isConnecting;
    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "1";

    #endregion

    #region MonoBehaviour CallBacks

    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
      
    }

    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        controlPanel.SetActive(true);
        Modes_panel.SetActive(false);    
    }

    #endregion


    #region Public Methods

    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
       
        
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            Modes_panel.SetActive(true );
            
            //my    PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
           isConnecting =   PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
            
        }
    }

    #endregion

    
    public void OnClick_CreateRoom()
    {
        string name = _roomName.text;
        PhotonNetwork.CreateRoom(name, new RoomOptions());
    }

    public void onClick_JoinRandomRoom()
    {
        if (PhotonNetwork.IsConnected || isConnecting == false)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        if(isConnecting)
        {
            //   PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.JoinLobby();
            isConnecting=false;
            Modes_panel.SetActive(true);
            controlPanel.SetActive(false);
        }
    }

   
    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created Succesfully");
        Create_Room_Panel.SetActive(false);
        browse_Players_Panel.SetActive(true);
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
       
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions());
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        // #Critical: We only load if we are the first player, else we rely on `PhotonNetwork.AutomaticallySyncScene` to sync our instance scene.
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("Entered Room....." );

            // #Critical
            // Load the Room Level.
      //      PhotonNetwork.LoadLevel("Room for 1");
             controlPanel.SetActive(false );  
        }
        browse_Players_Panel.SetActive(true );
        Browse_Room_Panels.SetActive(false);
    }

    #endregion
}
