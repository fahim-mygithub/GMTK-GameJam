using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    /*
    private void Start()
    {
        instance = this;
    }
    */

    public LayerMask pUnitLayer, eUnitLayer;

    public Character character;
    public Transform spawnPoint;
    public bool isPlayer;
    void Start()
    {
        instance = this;
        pUnitLayer = LayerMask.NameToLayer("Enemy Units");
        eUnitLayer = LayerMask.NameToLayer("Player Units");
        GameObject unit = Instantiate(character.unitPrefab, transform.position, Quaternion.identity, spawnPoint);
        initializeUnitStats(unit.GetComponent<Unit>(), character);
        Vector3 new_position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        unit.transform.position = new_position;
        GameObject unit2 = Instantiate(character.unitPrefab, transform.position, Quaternion.identity, spawnPoint);
        initializeUnitStats(unit2.GetComponent<Unit>(), character);

        LayerMask layerToSet = isPlayer ? pUnitLayer : eUnitLayer;
        unit.layer = layerToSet;
        unit2.layer = layerToSet;
    }

    void initializeUnitStats(Unit unit, Character character)
    {
        unit.stats = character.unitStats;
        unit.isPlayer = character.isPlayerUnit;
    }
}
