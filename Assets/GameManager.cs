using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Store the current score for both teams
    public int blueScore = 0;
    public int redScore = 0;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    instance = gameManagerObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increment the blue team's score
    public void IncrementBlueScore()
    {
        blueScore++;
    }

    // Method to increment the red team's score
    public void IncrementRedScore()
    {
        redScore++;
    }

    // Method to update scores based on the team and scoreValue
    public void UpdateScore(int scoreValue, string team)
    {
        if (team == "Blue")
        {
            blueScore += scoreValue;
        }
        else if (team == "Red")
        {
            redScore += scoreValue;
        }
    }

    // Method to retrieve the blue team's score
    public int GetBlueScore()
    {
        return blueScore;
    }

    // Method to retrieve the red team's score
    public int GetRedScore()
    {
        return redScore;
    }
}