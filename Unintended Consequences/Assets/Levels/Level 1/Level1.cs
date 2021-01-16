using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Level1 : NetworkBehaviour
{   [SyncVar]
	private CharacterHP character_hp;
    private GameObject[] Players;
    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject player in Players)
        {
            character_hp = player.GetComponent<CharacterHP>();
            character_hp.currentHealth = 5f;
        }
        
        Debug.Log("2xhp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
