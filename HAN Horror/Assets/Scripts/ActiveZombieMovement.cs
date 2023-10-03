using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActiveZombieMovement : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform goal;
    
    enum States
    {
        Patrol,
        Aggro
    }
    private States currentState;

    public Transform[] patrolPoints;

    void Start()
    {
        currentState = States.Patrol;
        
        agent = GetComponent<NavMeshAgent>();
        goal = transform;

    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Patrol:
                
                break;
            
            case States.Aggro:
                break;
        }
    }
    
    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
    
}


/*
if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
                
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;
            }
        }
        */
// goal.position = new Vector3(goal.position.x, goal.position.y, 6.5f);
//
// Debug.Log("Goal: " + goal);
// Debug.Log("Agent: " + agent);
//
// agent.destination = transform.position - goal.position;