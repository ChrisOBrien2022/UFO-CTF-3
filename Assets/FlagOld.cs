//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FlagOld : MonoBehaviour
//{
//    private Vector3 originalPosition; // Store the original position of the flag
//    private bool isCarryingFlag = false;

//    void Start()
//    {
//        // Store the original position of the flag
//        originalPosition = transform.position;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("OnTriggerEnter triggered. Colliding GameObject: " + other.name);


//        // Check if the colliding GameObject is a player and if the flag is not already being carried
//        if (isCarryingFlag || !other.CompareTag("BluePlayer") && !other.CompareTag("RedPlayer"))
//        {
//            Debug.Log("Not picking up flag. Already carrying flag or not a player.");
//            return;
//        }



//        // Check if the flag being picked up matches the player's team color
//        if (CompareTag("BlueFlag") && other.CompareTag("BluePlayer") ||
//            CompareTag("RedFlag") && other.CompareTag("RedPlayer"))
//        {
//            // Pick up the flag
//            transform.SetParent(other.transform); // Attach flag to player
//            transform.localPosition = Vector3.zero; // Center the flag relative to the player
//            isCarryingFlag = true;
//            // Flag picked up logic...

//            Debug.Log("Flag picked up by: " + other.name);
//        }

//        if (other.CompareTag("BluePlayer") && isCarryingFlag)
//        {
//            // Collided with BlueBase while carrying the flag as BluePlayer
//            Debug.Log("BluePlayer collided with BlueBase while carrying the flag.");

//            // Reset the flag to its original position at the RedBase
//            transform.position = originalPosition;
//            isCarryingFlag = false;

//            // Increment BlueScore by 1
//            GameManager.Instance.IncrementBlueScore();
//        }
//        else if (other.CompareTag("BlueBase") && !isCarryingFlag)
//        {
//            // Collided with BlueBase without carrying the flag
//            Debug.Log("BluePlayer collided with BlueBase without carrying the flag.");
//        }
//    }
//}
