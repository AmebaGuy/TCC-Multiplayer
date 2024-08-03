using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoundManager : MonoBehaviourPunCallbacks
{
    private bool isRoundActive = false;
    public GameObject cylinder;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {
        if (!isRoundActive && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            StartRound();
        }
    }

    void StartRound()
    {
        isRoundActive = true;
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("RPC_StartRound", RpcTarget.All);
    }

    [PunRPC]
    void RPC_StartRound()
    {
        Debug.Log("Round Started");
        PhotonNetwork.Instantiate(cylinder.name, new Vector3(0, 15, 0), Quaternion.Euler(0, 0, 4));
    }

    public void EndRound()
    {
        isRoundActive = false;
        photonView.RPC("RPC_EndRound", RpcTarget.All);
    }

    [PunRPC]
    void RPC_EndRound()
    {
        Debug.Log("Round Ended");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2 && isRoundActive)
        {
            EndRound();
        }
    }
}
