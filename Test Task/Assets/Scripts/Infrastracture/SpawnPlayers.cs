using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -8f;
    public float maxZ = -2f;
    public float y = 1.13f;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}