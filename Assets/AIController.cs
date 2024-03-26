using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    // Enum for different AI states
    public enum AiState
    {
        Idle,
        MovingToEnemyBase,
        CapturingFlag,
        ReturningToHomeBase,
        DefendingHomeBase
    }

    //// Current state of the AI
    //private AiState currentState;

    //// Reference to enemy base, home base, and flag
    //public GameObject enemyBase;
    //public GameObject homeBase;
    //public GameObject flag;

    //// Reference to the GameManager
    //private GameManager gameManager;

    //// Variables for movement and other behaviors
    //private NavMeshAgent agent;
    //private bool flagCaptured;

    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    gameManager = GameManager.Instance; // Get reference to the GameManager
    //    currentState = AiState.Idle;
    //}

    //void Update()
    //{
    //    // Update AI behavior based on current state
    //    switch (currentState)
    //    {
    //        case AiState.Idle:
    //            IdleBehavior();
    //            break;
    //        case AiState.MovingToEnemyBase:
    //            MovingToEnemyBaseBehavior();
    //            break;
    //        case AiState.CapturingFlag:
    //            CapturingFlagBehavior();
    //            break;
    //        case AiState.ReturningToHomeBase:
    //            ReturningToHomeBaseBehavior();
    //            break;
    //        case AiState.DefendingHomeBase:
    //            DefendingHomeBaseBehavior();
    //            break;
    //    }
    //}

    //// Add methods for transitioning between states
    //private void TransitionToState(AiState newState)
    //{
    //    currentState = newState;
    //}

    //// Add methods for specific state behaviors
    //private void IdleBehavior()
    //{
    //    // Transition to MovingToEnemyBase state when conditions are met
    //    if (/* Condition for transitioning to MovingToEnemyBase */)
    //    {
    //        TransitionToState(AiState.MovingToEnemyBase);
    //    }
    //}

    //private void MovingToEnemyBaseBehavior()
    //{
    //    // Move towards the enemy base
    //    agent.SetDestination(enemyBase.transform.position);

    //    // Transition to CapturingFlag state if AI is close to the flag
    //    if (Vector3.Distance(transform.position, flag.transform.position) < 1.5f)
    //    {
    //        TransitionToState(AiState.CapturingFlag);
    //    }
    //}

    //private void CapturingFlagBehavior()
    //{
    //    // Interact with the flag to capture it
    //    // Assuming the flag is a trigger collider and captures the flag when the AI enters it

    //    // Transition to ReturningToHomeBase state after capturing the flag
    //    if (flagCaptured)
    //    {
    //        TransitionToState(AiState.ReturningToHomeBase);

    //        // Reset the scene if flag is captured
    //        gameManager.ResetScene();
    //    }
    //}

    //private void ReturningToHomeBaseBehavior()
    //{
    //    // Move towards the home base
    //    agent.SetDestination(homeBase.transform.position);

    //    // Transition to Idle state if AI reaches home base
    //    if (Vector3.Distance(transform.position, homeBase.transform.position) < 1.5f)
    //    {
    //        TransitionToState(AiState.Idle);
    //    }
    //}

    //private void DefendingHomeBaseBehavior()
    //{
    //    // Implement behavior for defending home base
    //}
}