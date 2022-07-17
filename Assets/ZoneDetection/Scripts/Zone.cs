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
        if (other.tag == "Die" && !other.GetComponent<Rigidbody>().isKinematic)
        {
            if (other.GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
            {
                transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Die")
        {
            transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_Color", original_color);
        }
    }
}
