using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    private Vector3 originalPosition; // Store the original position of the flag
    private bool isCarryingFlag = false;
    private string team; // Team of the flag ("Blue" or "Red")

    void Start()
    {
        // Store the original position of the flag
        originalPosition = transform.position;

        // Assign team based on the tag of the flag
        if (CompareTag("BlueFlag"))
        {
            team = "Blue";
        }
        else if (CompareTag("RedFlag"))
        {
            team = "Red";
        }
        else
        {
            Debug.LogError("Flag tag not recognized: " + gameObject.tag);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter triggered. Colliding GameObject: " + other.name);

        // Check if the colliding GameObject is a player and if the flag is not already being carried
        if (!isCarryingFlag && other.CompareTag(team + "Player"))
            {
                // Pick up the flag
                transform.SetParent(other.transform); // Attach flag to player
                transform.localPosition = Vector3.zero; // Center the flag relative to the player
                isCarryingFlag = true; // Flag is now being carried
                Debug.Log("Flag picked up by: " + other.name);
            }
        else if (isCarryingFlag && other.CompareTag(team + "Base"))
        {
            // Check if the player's home base is reached while carrying the flag
            if (other.CompareTag(team + "Base"))
            {
                Debug.Log("Player reached home base with the flag.");

                // Reset the flag to its original position
                transform.position = originalPosition;
                isCarryingFlag = false; // Flag is no longer being carried
                transform.SetParent(null); // Detach flag from player

                // Increment the corresponding team's score
                if (team == "Blue")
                {
                    GameManager.Instance.IncrementBlueScore();
                }
                else if (team == "Red")
                {
                    GameManager.Instance.IncrementRedScore();
                }
            }
            else if (isCarryingFlag && other.CompareTag("Player"))
            {
                // Check if another player touches the flag while it's being carried
                Debug.Log("Another player touched the flag."); // Add this debug log statement
                Debug.Log("Flag team: " + team);
                Debug.Log("Player team: " + other.GetComponent<BluePlayerMovement>().team);

                // Reset the flag to its original position
                transform.position = originalPosition;
                isCarryingFlag = false; // Flag is no longer being carried
                transform.SetParent(null); // Detach flag from player
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        // Flag behavior during gameplay can be added here if needed
    }

}
