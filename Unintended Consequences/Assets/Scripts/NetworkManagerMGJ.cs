using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerMGJ : NetworkManager
{
    // Start is called before the first frame update
    public Transform LeftPlayerSpawn;
    public Transform RightPlayerSpawn;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? LeftPlayerSpawn : RightPlayerSpawn;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

    }
    public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
        
        }

}
