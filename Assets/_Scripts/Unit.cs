using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    public UnitStatTypes.Base stats;
    public float health;
    public bool isPlayer;

    public Color kalm;
    public Color hunt;
    public Color atak;

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
