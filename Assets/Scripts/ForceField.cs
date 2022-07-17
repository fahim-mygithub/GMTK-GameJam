using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public static BoxCollider bcForceField;
    public static MeshCollider mcForceField;
    public static bool currentlyTrapping;
    // Start is called before the first frame update
    void Start()
    {
        bcForceField = gameObject.GetComponent<BoxCollider>();
        mcForceField = gameObject.GetComponent<MeshCollider>();
        Debug.Log("ff loaded");
        currentlyTrapping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        GameObject colObj = collision.gameObject;

        D6Dice d6 = colObj.GetComponent<D6Dice>();
        if (d6 == null || currentlyTrapping)
        {
            return;
        }

        bcForceField.enabled = false;
        mcForceField.enabled = false;
        currentlyTrapping = true;

    }
}
