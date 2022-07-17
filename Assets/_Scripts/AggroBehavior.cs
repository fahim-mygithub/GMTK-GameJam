using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AggroBehavior : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Collider[] rangeColliders;

    LayerMask aggroLayer;
    private Transform aggroTarget;
    private Unit aggroUnit;
    private bool hasAggro = false;

    private float distance = float.MaxValue;

    private UnitStatTypes.Base unitStats;

    private float atkCooldown;
    private float aggroRange;

    private Renderer renderer;
    private Color kalm;
    private Color hunt;
    private Color atak;

    private void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        Unit unit = gameObject.GetComponent<Unit>();
        unitStats = unit.stats;
        aggroLayer = unit.isPlayer ? Spawner.instance.eUnitLayer : Spawner.instance.pUnitLayer;

        kalm = unit.kalm;
        hunt = unit.hunt;
        atak = unit.atak;
        
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", kalm);
    }

    private void Update()
    {
        atkCooldown -= Time.deltaTime;
        aggroRange += Time.deltaTime;
        if (!hasAggro)
        {
            CheckForEnenmyTargets();
            renderer.material.SetColor("_Color", kalm);
        } else
        {
            Attack();
            MoveToAggroTarget();
        }
    }

    private void Attack()
    {
        if (distance <= unitStats.atkRange + 1)
        {
            renderer.material.SetColor("_Color", atak);
            if (atkCooldown <= 0 && distance <= unitStats.atkRange)
            {
                aggroUnit.UpdateHealth(-unitStats.atkDmg);
                atkCooldown = unitStats.atkSpeed;
            }
        }
         else
        {
            renderer.material.SetColor("_Color", hunt);
        }
    }

    private void CheckForEnenmyTargets()
    {
        rangeColliders = Physics.OverlapSphere(transform.position, aggroRange * 10);
        for (int i = 0; i < rangeColliders.Length; i++)
        {
            if (rangeColliders[i].gameObject.layer == aggroLayer)   //Doesn't resolve to true
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
            aggroRange = aggroRange / 4;
        } else
        {
            distance = Vector3.Distance(aggroTarget.position, transform.position);
            navAgent.stoppingDistance = (unitStats.atkRange);
            navAgent.SetDestination(aggroTarget.position);
        }
    }
}
