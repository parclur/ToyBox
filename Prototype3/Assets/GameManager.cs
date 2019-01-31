using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script is located under the GameManager object and is used to...
public class GameManager : MonoBehaviour
{
    //timer
    public float timer;
    public TextMeshProUGUI timerText;

    //score
    public float score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f; // in seconds; sets the countdown to the selected game length
        Time.timeScale = 1;

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // updates the timer in the UI
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f0");

        // tests to see if the score is being added
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddPoints(1);
        }
    }

    // called each time the player earns points
    public void AddPoints(int pointsAdded)
    {
        score += pointsAdded;
        scoreText.text = score.ToString();
    }
}