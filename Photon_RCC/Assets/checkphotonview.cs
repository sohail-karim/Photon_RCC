using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkphotonview : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            Debug.Log("Photon view is mine");
        }
        else
        {
            Debug.Log("Photon View is not Mine");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
