using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Xml.Schema;
public class RoomsListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    [Tooltip("Prefab of Rooms Names")]
    private RoomListing _roomlisting;

     
    [SerializeField]
    [Tooltip("Transform where to instantiate RoomListing Prefab")]
    private Transform _content;

    private List<RoomListing> _listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        Debug.Log("This Function is called" + roomList.Count);
        foreach (RoomInfo info in roomList)
        {
            string password = (string)info.CustomProperties["Password"];
            Debug.Log("Password for this room is : " + password);
            //Removed from rooms list.

            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                int index = _listings.FindIndex(_x => _x.RoomInfo.Name == info.Name);
                if(index == -1)
                {
                 
                    RoomListing listing = Instantiate(_roomlisting, _content);
                    if (listing != null)
                    {
                        ///assining password here to prefab of listings of rooms data.....
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                else
                {
                    // Modify Listing Here..
                    //Listings[index].whatever do here....
                }
            }
        }
    }

    public override void OnJoinedRoom()
    {
      //  _content.DestroyChildren();
    }
}
