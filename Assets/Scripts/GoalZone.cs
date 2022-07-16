using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private bool announced;
    // Start is called before the first frame update
    void Start()
    {

        announced = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider col)
    {
        Debug.Log("Stay");
        if(col.transform.tag != "Dice")
        {
            return;
        }

        D6Dice d6 = col.gameObject.GetComponent<D6Dice>();
        if (d6.DiceVelocity.x == 0f && d6.DiceVelocity.y == 0f && d6.DiceVelocity.z == 0f && !announced)
        {
            Transform topSide = d6.FindTopside();
            Debug.Log(gameObject.name + " / " + topSide.name);
        }
    }
}
