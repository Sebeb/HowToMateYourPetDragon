﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public DragonMain player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponent<DragonMain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(player.currentHealth);
        }
        else
        {
            player.currentHealth = (int)stream.ReceiveNext();
        }
    }
}
