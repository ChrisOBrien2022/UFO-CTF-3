using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ScoreUi : MonoBehaviour
{
    public TextMeshProUGUI BlueScoreText;
    public TextMeshProUGUI RedScoreText;
    public TextMeshProUGUI MainText;

    private GameManager gameManager;

    void Start()
    {
        // Find and cache the GameManager instance
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager instance is null in ScoreUi.");
        }
        else
        {
            Debug.Log("GameManager instance found in ScoreUi.");
        }
    }

    void Update()
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager instance is null in ScoreUi Update().");
            return;
        }

        // Update the UI Text elements with current scores
        BlueScoreText.text = gameManager.blueScore.ToString();
        RedScoreText.text = gameManager.redScore.ToString();

        // Check for winner
        if (gameManager.blueScore >= 5)
        {
            MainText.text = "Blue Wins!";
        }
        else if (gameManager.redScore >= 5)
        {
            MainText.text = "Red Wins!";
        }
        else
        {
            MainText.text = ""; // Keep MainText blank if no team has won yet
        }
    }
}