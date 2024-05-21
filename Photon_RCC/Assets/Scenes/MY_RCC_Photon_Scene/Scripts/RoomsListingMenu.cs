using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Xml.Schema;
public class RoomsListingMenu : MonoBehaviourPunCallbacks
{

    public bool FilterRoomsWithPassword;
    [SerializeField]
    [Tooltip("Prefab of Rooms Names")]
    private RoomListing _roomlisting;

    
    [SerializeField]
    [Tooltip("Transform where to instantiate RoomListing Prefab")]
    private Transform Private_content;


    [SerializeField]
    [Tooltip("Transform where to instantiate RoomListing Prefab")]
    private Transform Public_Content;



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
                    database.roomslist.Remove(info.Name);
                }
            }
            else
            {
                if (password == null || password.Length == 0)
                {
                    int index = _listings.FindIndex(_x => _x.RoomInfo.Name == info.Name);

                    if (index == -1)
                    {
                        RoomListing listing = Instantiate(_roomlisting, Public_Content);
                        if (listing != null)
                        {
                            ///assining password here to prefab of listings of rooms data.....
                            listing.SetRoomInfo(info);
                     //       database.roomslist.Add(info.Name, (string)info.CustomProperties["Password"]);

                     //       Debug.Log("Rooms List count. in dictonary..." + database.roomslist.Count);
                            _listings.Add(listing);
                        }
                    }
                    else
                    {
                        // Modify Listing Here..
                        //Listings[index].whatever do here....
                    }
                }
                else
                {
                        int index = _listings.FindIndex(_x => _x.RoomInfo.Name == info.Name);

                        if (index == -1)
                        {

                            RoomListing listing = Instantiate(_roomlisting, Private_content);

                            if (listing != null)
                            {
                                ///assining password here to prefab of listings of rooms data.....
                                      listing.SetRoomInfo(info);
                                      database.roomslist.Add(info.Name, (string)info.CustomProperties["Password"]);

                                //       Debug.Log("Rooms List count. in dictonary..." + database.roomslist.Count);
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
    }

    public override void OnJoinedRoom()
    {
      //  _content.DestroyChildren();
    }
}
