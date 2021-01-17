using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerShooterLvl6 : NetworkBehaviour
{

    public Transform firePoint;
    public GameObject bulletToFire;

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
        bulletColor = bulletColors[NetworkServer.connections.Count - 1]; // -1 to ignore current player
    }

    // Update is called once per frame
    [Command]
    void CmdSpawnBullet(float angle)
    {
        //bulletClone.GetComponent<Rigidbody>().velocity = nozzle.transform.forward * bulletSpeed;
        RpcSpawnBullet(angle);
    }

    [ClientRpc]

    void RpcSpawnBullet(float angle)
    {
        GameObject bulletClone = Instantiate(bulletToFire, firePoint.position, Quaternion.Euler(0f, 0f, angle));
        bulletClone.GetComponent<BulletController>().dontDamage = this.gameObject;
        bulletClone.GetComponent<SpriteRenderer>().color = bulletColor;
        if (myParticleSystem) myParticleSystem.Play();
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            Vector3 mouse = Input.mousePosition;

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

            Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg  + 10;

            //transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (Input.GetMouseButtonDown(0))
            {
                CmdSpawnBullet(angle);
            }
        }
    }
}
