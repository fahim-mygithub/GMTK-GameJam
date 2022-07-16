using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    Vector3 diceVelocity;
    bool ann;

    private void Start()
    {
        ann = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && !ann) 
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                    //dicenumbertextscript.dicenumber = 6;
                    Debug.Log("6");
                    ann = true;
                    break;
                case "Side2":
                    //dicenumbertextscript.dicenumber = 5;
                    Debug.Log("5");
                    ann = true;
                    break;
                case "Side3":
                    //dicenumbertextscript.dicenumber = 4;
                    Debug.Log("4");
                    ann = true;
                    break;
                case "Side4":
                    //dicenumbertextscript.dicenumber = 3;
                    Debug.Log("3");
                    ann = true;
                    break;
                case "Side5":
                    //dicenumbertextscript.dicenumber = 2;
                    Debug.Log("2");
                    ann = true;
                    break;
                case "Side6":
                    //dicenumbertextscript.dicenumber = 1;
                    Debug.Log("1");
                    ann = true;
                    break;
            }
        }
    }
}

