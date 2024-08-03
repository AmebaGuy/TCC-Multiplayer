using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
<<<<<<< HEAD
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
        photonView.RPC("RPC_StartRound", RpcTarget.All);
    }

    [PunRPC]
    void RPC_StartRound()
    {
        Debug.Log("Round Started");
        PhotonNetwork.Instantiate(cylinder.name, new Vector3(0,15,0), Quaternion.Euler(0,0,4));
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
=======

public class RoundsManager : MonoBehaviourPunCallbacks
{
    public float roundDuration = 60f; // Round duration in seconds
    private RoundState currentRoundState = RoundState.WaitingForPlayers;
    private float roundTimer;

    public GameObject obstaclePrefab;

    private enum RoundState
    {
        WaitingForPlayers,
        InProgress,
        RoundEnd
    }

    private void Start()
    {
        // Initialize round state and start the first round
        currentRoundState = RoundState.WaitingForPlayers;
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        yield return new WaitForSeconds(3f); // Wait for players to join

        currentRoundState = RoundState.InProgress;
        roundTimer = roundDuration;

        while (roundTimer > 0f)
        {
            // Update round timer
            roundTimer -= Time.deltaTime;
            yield return null;
        }

        // Round end logic (e.g., determine winner, reset game state)
        PhotonNetwork.Instantiate(obstaclePrefab.name, new Vector3(0,15,0), Quaternion.Euler(0, 0, 0));
        EndRound();                                    
    }

    private void EndRound()
    {
        currentRoundState = RoundState.RoundEnd;
        // Implement round end actions (e.g., display results, reset player positions)

        // Start the next round (if applicable)
        StartCoroutine(StartRound());
    }

    // Example RPCs (you'll need to customize these based on your game logic)
    [PunRPC]
    private void RpcStartRound()
    {
        // Start the round on all clients
        StartCoroutine(StartRound());
    }

    [PunRPC]
    private void RpcEndRound()
    {
        // End the round on all clients
        EndRound();
>>>>>>> e01ffc2a92400e758f7d8b83e29363ae1568d8b5
    }
}
