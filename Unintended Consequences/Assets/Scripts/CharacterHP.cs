using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class CharacterHP : NetworkBehaviour
{
    public float maxHealth;
    [SyncVar]
    public float currentHealth;
    private Slider mySlider;
    public SpriteRenderer mySpriteRenderer; 

    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = 20f;
        currentHealth = maxHealth;
        mySlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        mySlider.value = 1 - currentHealth / maxHealth;
    }




    public void onDamage(float damage)
    {
        StartCoroutine(Flash());
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Die()
    {
        currentHealth = 0;
        Debug.Log("you have died");
    }


    IEnumerator Flash()
    {
        Debug.Log("hello");
        if (currentHealth <= 20 && currentHealth>=16) { 
        mySpriteRenderer.color = new Color(255f/255f, 160f/255f, 122f/255f);
        }
        else if (currentHealth < 16 && currentHealth >= 10)
        {
            mySpriteRenderer.color = new Color(250f/255f, 128f/255f, 114f/255f);
        }
        else if (currentHealth < 10 && currentHealth >= 6)
        {
            mySpriteRenderer.color = new Color(220f/255f, 20f/255f, 60f/255f);
        }
        else if (currentHealth < 6 && currentHealth >= 0)
        {
            mySpriteRenderer.color = new Color(255f/255f, 0f/255f, 0f/255f);
        }

        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.color = Color.white;
    }
}