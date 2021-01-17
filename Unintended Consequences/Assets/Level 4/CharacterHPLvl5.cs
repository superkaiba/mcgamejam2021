using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class CharacterHPLvl5 : NetworkBehaviour
{
    public float maxHealth;
    [SyncVar]
    public float currentHealth;
    private Slider mySlider;
    public SpriteRenderer mySpriteRenderer;
    private NetworkManagerMGJ myNetworkManager;


    private Vector3 scaleChange;
    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = 20f;
        currentHealth = maxHealth;
        mySlider = GetComponentInChildren<Slider>();
        myNetworkManager = GameObject.FindGameObjectWithTag("manager").GetComponent<NetworkManagerMGJ>();
        scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

        mySlider.value = 1 - currentHealth / maxHealth;
        if (Input.GetKeyDown(KeyCode.X))
        {
            mySpriteRenderer.transform.localScale += scaleChange;
            Debug.Log("Dying");
            
        }
    }


    [Command]

    public void onDamage(float damage)
    {
        StartFlashCoroutineOnClients();
        currentHealth -= damage;
        mySpriteRenderer.transform.localScale += scaleChange;
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        if (isServer) CmdNextScene();
        ClientDie();
        Destroy(gameObject);
    }

    [ClientRpc]

    void ClientDie()
    {
        Destroy(gameObject);
    }

    [Command(ignoreAuthority =true)]
    void CmdNextScene()
    {
        myNetworkManager.NextScene();
    }

    [ClientRpc]
    void StartFlashCoroutineOnClients()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        Debug.Log("hello");
        if (currentHealth <= 20 && currentHealth >= 16)
        {
            mySpriteRenderer.color = new Color(255f / 255f, 160f / 255f, 122f / 255f);
        }
        else if (currentHealth < 16 && currentHealth >= 10)
        {
            mySpriteRenderer.color = new Color(250f / 255f, 128f / 255f, 114f / 255f);
        }
        else if (currentHealth < 10 && currentHealth >= 6)
        {
            mySpriteRenderer.color = new Color(220f / 255f, 20f / 255f, 60f / 255f);
        }
        else if (currentHealth < 6 && currentHealth >= 0)
        {
            mySpriteRenderer.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }

        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.color = Color.white;
    }
}