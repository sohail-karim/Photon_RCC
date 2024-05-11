using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class RoomsListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    [Tooltip("Prefab of Rooms Names")]
    private RoomListing _roomlisting;


    [SerializeField]
    [Tooltip("Transform where to instantiate RoomListing Prefab")]
    private Transform _content;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            RoomListing listing = Instantiate(_roomlisting, _content);
            if(listing != null)
            {
                listing.SetRoomInfo(info);
            }
        }
    }

}
