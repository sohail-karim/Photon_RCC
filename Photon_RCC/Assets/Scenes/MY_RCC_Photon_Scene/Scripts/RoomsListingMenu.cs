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

    private List<RoomListing> _listings = new List<RoomListing>();


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("This Function is called" + roomList.Count);
        
        foreach (RoomInfo info in roomList)
        {
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
            Debug.Log("We are inside Loop:");
            Debug.Log(info);
            RoomListing listing = Instantiate(_roomlisting, _content);
            if(listing != null)
            {
                listing.SetRoomInfo(info);
                _listings.Add(listing);
            }
        }
    }

}
