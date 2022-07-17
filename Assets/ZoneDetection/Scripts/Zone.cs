using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public bool landed_in = false;
    public Color original_color;

    public void Start()
    {
        original_color = transform.parent.gameObject.GetComponent<Renderer>().material.color;

    }
    void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Die" || other.tag == "Dice") && !other.GetComponent<Rigidbody>().isKinematic)
        {
            D6Dice d6 = other.GetComponent<D6Dice>();
            if(d6 == null)
            {
                return;
            }
            if (other.GetComponent<Rigidbody>().velocity.magnitude < 1.5f && !d6.PerformedAction)
            {
                //kill momentum
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                //perform dice landing logic
                transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

                //you must run FindtopSide() to determine the topside
                //it returns a transform, so you can directly call its name
                Debug.Log(d6.FindTopside().name);
                d6.PerformedAction = true;
                ForceField.currentlyTrapping = false;
                StartCoroutine(CleanupDice(other.gameObject));
            }
        }
    }

    private IEnumerator CleanupDice(GameObject objToDestroy)
    {
        Destroy(objToDestroy, 3);
        yield return new WaitForSeconds(3);
        transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_Color", original_color);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Die")
        {
            Debug.Log("Ping!");
            ForceField.bcForceField.enabled = true;
            ForceField.mcForceField.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Die" || other.tag == "Dice")
        {
            transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_Color", original_color);
        }
    }
}
