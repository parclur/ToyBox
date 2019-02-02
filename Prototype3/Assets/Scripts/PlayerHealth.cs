using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is on the player object and is used to keep track of the player's health
public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    public GameObject gameManager;
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();

        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // tests to see if the score is being added
        if (Input.GetKeyDown(KeyCode.S))
        {
            Damage(1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.layer == 9) // enemy already has tag Grounded
        if(collision.collider.GetType() == typeof(BoxCollider) && collision.gameObject.tag == "Enemy") // enemy already has tag Grounded
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
    public void Damage(int enemyStrength)
    {
        playerHealth -= enemyStrength;
        Debug.Log(playerHealth);
        gameManagerScript.HealthUI(playerHealth);
    }

    // adds one to the player's health when they pick up a lightbulb
    public void PickUpLightBulb()
    {
        playerHealth += 1;
    }
}
