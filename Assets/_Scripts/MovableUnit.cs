using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class movableUnit : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void OnEnable()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveUnit(Vector3 destination)
    {
        navAgent.SetDestination(destination);
    }
}
