using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestValues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.total_a_units + " / " + GameManager.total_b_units + " / " + GameManager.total_c_units);
    }
}
