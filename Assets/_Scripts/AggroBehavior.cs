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
    private Unit aggroUnit;
    private bool hasAggro = false;

    private float distance;

    private UnitStatTypes.Base unitStats;

    private float atkCooldown;

    private void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        unitStats = gameObject.GetComponent<Unit>().stats;
    }

    private void Update()
    {
        atkCooldown -= Time.deltaTime;
        if (!hasAggro)
        {
            CheckForEnenmyTargets();
        } else
        {
            Attack();
            MoveToAggroTarget();
        }
    }

    private void Attack()
    {
        if (atkCooldown <= 0 && distance <= 1.5f)
        {
            aggroUnit.UpdateHealth(-1);
            atkCooldown = 1; 
        }
    }

    private void CheckForEnenmyTargets()
    {
        rangeColliders = Physics.OverlapSphere(transform.position, 100);
        for (int i = 0; i < rangeColliders.Length; i++)
        {
            if (rangeColliders[i].gameObject.layer == UnitHandler.instance.eUnitLayer)
            {
                aggroTarget = rangeColliders[i].gameObject.transform;
                aggroUnit = aggroTarget.transform.GetComponent<Unit>();
                hasAggro = true;
                break;
            }
        }
    }

    private void MoveToAggroTarget()
    {
        if (aggroTarget == null)
        {
            navAgent.SetDestination(transform.position);
            hasAggro = false;
        } else
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
}
