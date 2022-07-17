using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Constants instance;

    public LayerMask pUnitLayer, eUnitLayer;

    void Awake()
    {
        instance = this;
        pUnitLayer = LayerMask.NameToLayer("Enemy Units");
        eUnitLayer = LayerMask.NameToLayer("Player Units");
    }
}
