using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float aggroRange, atkRange, atkSped, attack, health, armor;
    public UnitStatTypes.Base stats;

    public void UpdateHealth(float delta)
    {
        health += delta;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
