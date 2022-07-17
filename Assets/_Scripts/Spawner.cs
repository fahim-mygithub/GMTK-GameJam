using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public LayerMask pUnitLayer, eUnitLayer;

    public Character character;
    public Transform parent_transform;
    public bool isPlayer;
    public int spawnAmount = 3;
    public bool autoSpawn = false;
    void Start()
    {
        instance = this;
        pUnitLayer = LayerMask.NameToLayer("Enemy Units");
        eUnitLayer = LayerMask.NameToLayer("Player Units");
        if (autoSpawn)
        {
            Spawn(spawnAmount);
        }
    }

    void Spawn(int amount)
    {
        LayerMask layerToSet = isPlayer ? Spawner.instance.pUnitLayer : Spawner.instance.eUnitLayer;
        Vector3 spawn_point = transform.position;
        int direction_x = 1;
        int direction_z = 1;
        bool flip_x = false;
        bool flip_z = false;
        float x_incr = 0;
        float z_incr = 0;
        for (int i = 0; i < amount; i++)
        {
            GameObject unit12 = Instantiate(character.unitPrefab, spawn_point, Quaternion.identity, parent_transform);
            InitializeUnitStats(unit12.GetComponent<Unit>(), character);
            x_incr += Random.Range(0.75f, 2.0f);
            z_incr += Random.Range(0.75f, 1.5f);
            if (flip_x && flip_z)
            {
                direction_x = -1;
                direction_z = -1;
                flip_x = false;
            } else if (flip_x && !flip_z)
            {
                direction_x = -1;
                direction_z = 1;
                flip_z = true;
            }
            else if (!flip_x && flip_z)
            {
                direction_x = 1;
                direction_z = -1;
                flip_z = false;
            }
            else if (!flip_x && !flip_z)
            {
                direction_x = 1;
                direction_z = 1;
                flip_x = true;
            }
            spawn_point.x += direction_x * x_incr;
            spawn_point.z += direction_z * z_incr;
            unit12.layer = layerToSet;
        }
    }

    void InitializeUnitStats(Unit unit, Character character)
    {
        unit.stats = character.unitStats;
        unit.isPlayer = character.isPlayerUnit;
    }
}
