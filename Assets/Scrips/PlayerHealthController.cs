using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;
    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSr;
    public GameObject deathEffect;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        theSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter = Time.deltaTime;

        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth--;
            PlayerController.instance.anim.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
            }

            UIController.instance.UpdateHealthDisplay();
        }

    }
}
