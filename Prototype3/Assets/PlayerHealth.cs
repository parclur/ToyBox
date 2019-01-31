using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is on the player object and is used to keep track of the player's health
public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Damage(1);
        }

        if(collision.gameObject.tag == "Light")
        {
            PickUpLightBulb();
            Destroy(gameObject);
        }
    }

    // accessor for the player health
    public int GetHealth()
    {
        return playerHealth;
    }

    // takes the damage based on the enemy
    void Damage(int enemyStrength)
    {
        playerHealth -= enemyStrength;
    }

    // adds one to the player's health when they pick up a lightbulb
    public void PickUpLightBulb()
    {
        playerHealth += 1;
    }
}
