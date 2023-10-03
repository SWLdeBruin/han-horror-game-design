using UnityEngine;
using UnityEngine.AI;

public class IdleZombieMovement : MonoBehaviour
{
    
    private NavMeshAgent agent;
    public Transform goal;
    
    private GameObject player;
    private float aggroDistance = 3;

    
    enum States
    {
        Idle,
        Aggro
    }
    private States currentState;

    private void Start()
    {
        player = GameObject.Find("Player");
        
        currentState = States.Idle;

        agent = GetComponent<NavMeshAgent>();
        agent.destination = transform.position;

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
                }
                break;

            case States.Aggro:
                agent.destination = player.transform.position;
                
                // Transition to Patrol
                if ((transform.position - player.transform.position).magnitude > aggroDistance)
                {
                    currentState = States.Idle;
                }
                break;
        }
    }
}
