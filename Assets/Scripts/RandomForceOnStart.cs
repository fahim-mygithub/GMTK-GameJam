using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForceOnStart : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    [SerializeField]
    private float m_Thrust;
    // Start is called before the first frame update







    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();


        //Rng roll dice
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
        float rngJump = Random.Range(0, m_Thrust);
        m_Rigidbody.AddForce(transform.up * rngJump);







    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
