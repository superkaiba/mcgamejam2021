using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
public class NetworkManagerMGJ : NetworkManager
{
    // Start is called before the first frame update
    public Transform LeftPlayerSpawn;
    public Transform RightPlayerSpawn;
    public Vector3 startingPosition1;
    public Vector3 startingPosition2;

    public int currentLevel;
    public string[] levelNames = { "Level 1", "Level " };
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
            // add player at correct spawn position
            Vector3 start = numPlayers == 0 ? startingPosition1 : startingPosition2;
            GameObject player = Instantiate(playerPrefab, start, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player);

    }
    public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
        
        }

    public void OnServerSceneChanged()
    {
        foreach (var conn in NetworkServer.connections)
        {
            Debug.Log(currentLevel);
            Debug.Log("nani");
            Vector3 start = numPlayers == 0 ? startingPosition1 : startingPosition2;
            GameObject player = Instantiate(playerPrefab, start, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn.Value, player);
        }
    }
    public void NextScene()
    {
        currentLevel = Random.Range(1, SceneManager.sceneCountInBuildSettings + 1);
        playerPrefab = playerPrefabs[currentLevel - 1];
        ServerChangeScene("Level " + currentLevel);
        foreach (var conn in NetworkServer.connections)
        {
            NetworkServer.SetClientReady(conn.Value);
        }

        
    }

}
