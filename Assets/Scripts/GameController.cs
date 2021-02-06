﻿using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPun
{
    //Purpose:
    //  1. spawn new player in game

    public Transform[] SpawnPoint = null;

    public GameObject coin;

    private void Awake()
    {
        int i = 0;
        i = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        GameObject go = PhotonNetwork.Instantiate("Bulldog", SpawnPoint[i].position, SpawnPoint[i].rotation);

        Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);

        Instantiate(coin, new Vector3(10, 0, 0), Quaternion.identity);
    }

  
}
