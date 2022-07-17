using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float aggroRange, atkRange, attack, health, armor;
    public UnitStatTypes.Base stats;
}
