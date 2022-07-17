using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AggroBehavior : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Collider[] rangeColliders;
    
    private Transform aggroTarget;
    private bool hasAggro = false;

    private float distance;

    private UnitStatTypes.Base unitStats;

    private void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        unitStats = gameObject.GetComponent<UnitStatTypes.Base>();
    }

    private void Update()
    {
        if (!hasAggro)
        {
            CheckForEnenmyTargets();
        } else
        {
            moveToAggroTarget();
        }
    }

    private void CheckForEnenmyTargets()
    {
        rangeColliders = Physics.OverlapSphere(transform.position, 100);
        print("Test");
        for (int i = 0; i < rangeColliders.Length; i++)
        {
            if (rangeColliders[i].gameObject.layer == UnitHandler.instance.eUnitLayer)
            {
                aggroTarget = rangeColliders[i].gameObject.transform;
                hasAggro = true;
                break;
            }
        }
    }

    private void moveToAggroTarget()
    {
        distance = Vector3.Distance(aggroTarget.position, transform.position);
        // navAgent.stoppingDistance = (unitStats.atkRange + 1);
        navAgent.stoppingDistance = (1.5f);
        print("Printing unit stats!");
        // print(unitStats);
        // if (distance <= unitStats.aggroRange)
        if (distance <= 100)
        {
            navAgent.SetDestination(aggroTarget.position);
        }
    }
}
