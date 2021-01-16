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
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20f;
        currentHealth = maxHealth;
        mySlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            DealDamage(2);

        mySlider.value = 1 - currentHealth / maxHealth;
    }




    public void DealDamage(float damageValue)
    {
        currentHealth -= damageValue;
        if (currentHealth <= 0)
            Die();
    }


    void Die()
    {
        currentHealth = 0;
        Debug.Log("you have died");
    }
}