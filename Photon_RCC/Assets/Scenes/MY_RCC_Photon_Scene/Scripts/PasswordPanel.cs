using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PasswordPanel : MonoBehaviour
{
    public GameObject Password_Panel;
    private void OnEnable()
    {
        RoomListing._OnRoomButtonClicked += openPanel;
    }

    private void  openPanel()
    {
        Password_Panel.SetActive(true);
        Debug.Log("Passward Panel Triggered!!!!");
    }
}
