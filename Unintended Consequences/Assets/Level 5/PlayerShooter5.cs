using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerShooter5 : NetworkBehaviour
{
    public AudioSource myAudioSource;
    public Transform firePoint;
    public GameObject bulletToFire;
    NetworkManagerMGJ myNetworkManager;
    public Color[] bulletColors;

    [SyncVar]
    private Color bulletColor;
    ParticleSystem myParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(NetworkServer.connections.Count - 1);
        myParticleSystem = GetComponentInChildren<ParticleSystem>();

        // Change color of bullet for different players
        bulletColor = bulletColors[0]; // -1 to ignore current player
        myNetworkManager = GameObject.FindGameObjectWithTag("manager").GetComponent<NetworkManagerMGJ>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    [Command]
    void CmdSpawnBullet(float angle)
    {
        //bulletClone.GetComponent<Rigidbody>().velocity = nozzle.transform.forward * bulletSpeed;
        //GameObject bulletClone = Instantiate(bulletToFire, firePoint.position, Quaternion.Euler(0f, 0f, angle));
        //bulletClone.GetComponent<BulletController>().dontDamage = this.gameObject;
        //bulletClone.GetComponent<SpriteRenderer>().color = bulletColor;
        //NetworkServer.Spawn(bulletClone);
        RpcSpawnBullet(angle);
    }

    [ClientRpc]

    void RpcSpawnBullet(float angle)
    {
        GameObject bulletClone = Instantiate(bulletToFire, firePoint.position, Quaternion.Euler(0f, 0f, angle));
        bulletClone.GetComponent<BulletController>().dontDamage = this.gameObject;
        bulletClone.GetComponent<SpriteRenderer>().color = bulletColor;
        myAudioSource.Play();
        if (myParticleSystem) myParticleSystem.Play();
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            Vector3 mouse = Input.mousePosition;

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

            Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            float angle;
            // For level 5
            angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg + Random.Range(-90, 90);
           

            //transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (Input.GetMouseButtonDown(0))
            {
                CmdSpawnBullet(angle);
            }
        }
    }
}