using UnityEngine;
using UnityEngine.AI;

public class ActiveZombieMovement : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform startLocation;
    public Transform endLocation;

    private GameObject player;
    private float aggroDistance = 10;
    
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
        
        switch (currentState)
        {
            case States.Patrol:
                if (transform.position.x.Equals(endLocation.position.x) && transform.position.z.Equals(endLocation.position.z)) agent.destination = startLocation.position;
                if (transform.position.x.Equals(startLocation.position.x) && transform.position.z.Equals(startLocation.position.z)) agent.destination = endLocation.position;
                
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
                    currentState = States.Patrol;
                    agent.destination = startLocation.position;
                }
                
                break;
        }
    }
    
    
}