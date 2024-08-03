using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minX,maxX,minY,maxY;

    public List<PlayerBehaviour> playerBehaviours;

    public PlayerHUD playerUI;

    private void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        PlayerBehaviour playerLocal = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.Euler(0,0,4)).
            GetComponent<PlayerBehaviour>();
        playerUI.playerBehaviour = playerLocal;
        
    }
}
