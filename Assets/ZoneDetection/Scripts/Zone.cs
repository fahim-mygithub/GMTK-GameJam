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
            if (other.GetComponent<Rigidbody>().velocity.magnitude < 0.5f && !d6.PerformedAction)
            {
                transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                //d6.FindTopside();
                Debug.Log(d6.FindTopside().name);
                d6.PerformedAction = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Die")
        {
            Debug.Log("Ping!");
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
