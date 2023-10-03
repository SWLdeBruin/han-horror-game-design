using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActiveZombieMovement : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform goal;
    public Transform startLocation;
    public Transform endLocation;

    private GameObject player;
    
    enum States
    {
        Patrol,
        Aggro
    }
    private States currentState;

    void Start()
    {
        player = GameObject.Find("Player");
        
        currentState = States.Patrol;
        
        agent = GetComponent<NavMeshAgent>();
        agent.destination = endLocation.position;

    }

    private void Update()
    {
        
        // if (Input.GetMouseButtonDown(0)) {
        //     RaycastHit hit;
        //         
        //     if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
        //         agent.destination = hit.point;
        //     }
        // }
        
        switch (currentState)
        {
            case States.Patrol:
                if (transform.position.x.Equals(endLocation.position.x) && transform.position.z.Equals(endLocation.position.z)) agent.destination = startLocation.position;
                if (transform.position.x.Equals(startLocation.position.x) && transform.position.z.Equals(startLocation.position.z)) agent.destination = endLocation.position;
                
                // Transition to Aggro
                if ((transform.position - player.transform.position).magnitude <= 10)
                {
                    currentState = States.Aggro;
                }
                
                break;
            
            case States.Aggro:
                agent.destination = player.transform.position;

                // Transition to Patrol
                if ((transform.position - player.transform.position).magnitude > 10)
                {
                    currentState = States.Patrol;
                }
                
                break;
        }
    }
    
    // void GotoNextPoint() {
    //     // Returns if no points have been set up
    //     if (points.Length == 0)
    //         return;
    //
    //     // Set the agent to go to the currently selected destination.
    //     agent.destination = points[destPoint].position;
    //
    //     // Choose the next point in the array as the destination,
    //     // cycling to the start if necessary.
    //     destPoint = (destPoint + 1) % points.Length;
    // }


    // void Update () {
    //     // Choose the next destination point when the agent gets
    //     // close to the current one.
    //     if (!agent.pathPending && agent.remainingDistance < 0.5f)
    //         GotoNextPoint();
    // }
    
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