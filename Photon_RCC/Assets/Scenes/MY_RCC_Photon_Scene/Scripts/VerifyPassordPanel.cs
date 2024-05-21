using UnityEngine;
using TMPro;
using Photon.Pun;

public class VerifyPassordPanel : MonoBehaviour
{
    public TMP_InputField user_enter_password;
   
    public void CheckPasswordforConfirmation()
    {
        string key = database.roomselected;
        if (database.roomslist.TryGetValue(key, out string value))
        {
            if (value == user_enter_password.text)
            {
                Debug.Log("Password Correct : ");
                PhotonNetwork.JoinRoom(key);
            }
            else
            {
                Debug.Log("Password Incorrect");
            }
        }
        else
        {
            Debug.Log("This Room is Public");
            PhotonNetwork.JoinRoom(key);
        }
    }
}
