using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IdleZombieMovement : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform goal;

    private GameObject player;
    private float aggroDistance = 10;

    private Animator animator;

    enum States
    {
        Idle,
        Aggro,
        Scared
    }
    private States currentState;

    private void Start()
    {
        player = GameObject.Find("Player (1)");

        currentState = States.Idle;

        agent = GetComponent<NavMeshAgent>();
        agent.destination = transform.position;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Idle:
                // Transition to Aggro
                if ((transform.position - player.transform.position).magnitude <= aggroDistance)
                {
                    currentState = States.Aggro;
                    animator.SetBool("Run", true);
                }
                break;

            case States.Aggro:
                agent.destination = player.transform.position;

                // Transition to Patrol
                if ((transform.position - player.transform.position).magnitude > aggroDistance)
                {
                    currentState = States.Idle;
                    animator.SetBool("Run", false);
                }

                if ((transform.position - player.transform.position).magnitude < 1.5)
                {
                    animator.SetTrigger("Punch");
                    SceneManager.LoadScene("DeathScreen");
                }
                break;
        }
    }
}