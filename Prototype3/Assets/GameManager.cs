using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script is located under the GameManager object and is used to...
public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float timer;
    public TextMeshProUGUI timerText;

    [Header("Score")]
    public float score;
    public TextMeshProUGUI scoreText;

    [Header("Player Health")]
    public GameObject lightbulb1;
    public GameObject lightbulb2;
    public GameObject lightbulb3;
    public Image darkness;
    Color tempColor;
    float fullHealthAlpha = 0f;
    float twoHealthAlpha = 0.39f;
    float oneHealthAlpha = 0.59f;
    float noHealthAlpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f; // in seconds; sets the countdown to the selected game length
        Time.timeScale = 1;

        score = 0;

        tempColor = darkness.color;
    }

    // Update is called once per frame
    void Update()
    {
        // updates the timer in the UI
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f0");

        if (timer <= 0)
        {
            // Game Over
        }

        // tests to see if the score is being added
        if (Input.GetKeyDown(KeyCode.A))
        {
            HealthUI(1);
        }
    }

    // called each time the player earns points
    public void AddPoints(int pointsAdded)
    {
        score += pointsAdded;
        scoreText.text = score.ToString();
    }

    public void HealthUI(int playerHealth)
    {
        switch (playerHealth)
        {
            case 3:
                lightbulb1.SetActive(true);
                lightbulb2.SetActive(true);
                lightbulb3.SetActive(true);
                tempColor.a = fullHealthAlpha;
                darkness.color = tempColor; // screen is bright, no darkness
                break;
            case 2:
                lightbulb1.SetActive(true);
                lightbulb2.SetActive(true);
                lightbulb3.SetActive(false);
                tempColor.a = twoHealthAlpha;
                darkness.color = tempColor; 
                break;
            case 1:
                lightbulb1.SetActive(true);
                lightbulb2.SetActive(false);
                lightbulb3.SetActive(false);
                tempColor.a = oneHealthAlpha;
                darkness.color = tempColor; 
                break;
            case 0:
                lightbulb1.SetActive(false);
                lightbulb2.SetActive(false);
                lightbulb3.SetActive(false);
                tempColor.a = noHealthAlpha;
                darkness.color = tempColor; 
                break;
        }
    }
}