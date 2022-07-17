using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6Dice : MonoBehaviour
{

    [SerializeField]
    private Transform side1;
    [SerializeField]
    private Transform side2;
    [SerializeField]
    private Transform side3;
    [SerializeField]
    private Transform side4;
    [SerializeField]
    private Transform side5;
    [SerializeField]
    private Transform side6;

    private List<Transform> sides;

    private Transform top;

    private Rigidbody rb;

    private Vector3 diceVelocity;

    public Vector3 DiceVelocity { get => diceVelocity; set => diceVelocity = value; }


    private bool performedAction;
    public bool PerformedAction { get => performedAction; set => performedAction = value; }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        diceVelocity = rb.velocity;


        sides = new List<Transform>();
        sides.Add(side1);
        sides.Add(side2);
        sides.Add(side3);
        sides.Add(side4);
        sides.Add(side5);
        sides.Add(side6);

        //assign top to a random side
        top = side1;

        performedAction = false;






    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;
    }

    public Transform FindTopside()
    {
        foreach (Transform side in sides)
        {
            if(side.position.y > top.position.y)
            {
                top = side;
            }
        }
        return top;
    }


    void MeBug(string toLog)
    {
        Debug.Log(gameObject.name + " / " + toLog);
    }

}
