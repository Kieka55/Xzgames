using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    public List<Transform> patrolPoints;
    public PlayerController player;
    public float vievAngle;
      
   
    void Start()
    {
        
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    
    void Update()
    {
        NotisedPlayerUpdete();
        ChaseUpdate();
        PetrolUpdate();
    }

    private void PetrolUpdate()
    {
        if(! _isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
                    {
                        PickNewPatrolPoint();
                    }
        }
        
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position; 
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void NotisedPlayerUpdete()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < vievAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

}
