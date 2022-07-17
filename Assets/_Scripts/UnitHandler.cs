using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHandler : MonoBehaviour
{
    public static UnitHandler instance;

    /*
    private void Start()
    {
        instance = this;
    }
    */

    public LayerMask pUnitLayer, eUnitLayer;

    public Character _unit;
    public Transform spawnPoint;
    public bool isPlayer;
    void Start()
    {
        instance = this;
        pUnitLayer = LayerMask.NameToLayer("Enemy Units");
        eUnitLayer = LayerMask.NameToLayer("Player Units");
        GameObject unit = Instantiate(_unit.unitPrefab, transform.position, Quaternion.identity, spawnPoint);
        initializeUnitStats(unit.GetComponent<Unit>(), _unit.unitStats);
        Vector3 new_position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        unit.transform.position = new_position;
        GameObject unit2 = Instantiate(_unit.unitPrefab, transform.position, Quaternion.identity, spawnPoint);
        initializeUnitStats(unit2.GetComponent<Unit>(), _unit.unitStats);

        LayerMask layerToSet = isPlayer ? pUnitLayer : eUnitLayer;
        unit.layer = layerToSet;
        unit2.layer = layerToSet;
    }

    void initializeUnitStats(Unit unit, UnitStatTypes.Base stats)
    {
        unit.stats = stats;
    }
}
