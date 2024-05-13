using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    [Tooltip("Prefab of Player Names/Buttons")]
    private PlayerListing _playerlisting;

    [SerializeField]
    [Tooltip("Transform where to instantiate PlayerListing Prefab")]
    private Transform _content;


    private void Start()
    {
        GetCurrentRoomPlayers();
    }
    private void GetCurrentRoomPlayers()
    {
        if (PhotonNetwork.InRoom)
        {
            Debug.Log("Players : " + PhotonNetwork.CurrentRoom.Players);
            foreach (KeyValuePair<int, Player> playerinfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPlayerListing(playerinfo.Value);
            }
        }
        

    }
    private void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(_playerlisting, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _listings.Add(listing);
        }
    }
    private List<PlayerListing> _listings = new List<PlayerListing>();
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }
   
}
