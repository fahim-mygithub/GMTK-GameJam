using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitStatTypes))]
[CreateAssetMenu(fileName = "New Unit", menuName = "New Unit")]
public class Character : ScriptableObject
{
    public bool isPlayerUnit;
    public UnitStatTypes.Base unitStats;
    public GameObject unitPrefab;

    public enum CharacterType
    {
        Rock,
        Paper,
        Scissors
    }
    public CharacterType type;
}
