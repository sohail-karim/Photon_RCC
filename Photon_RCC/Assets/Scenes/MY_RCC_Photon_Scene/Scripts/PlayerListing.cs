using Photon.Realtime;
using UnityEngine;
using TMPro;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    // Start is called before the first frame update

    public Player Player { get; private set; }
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        _text.text = player.NickName;
    }
}
