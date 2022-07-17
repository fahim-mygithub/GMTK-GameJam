using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.a_image = GameObject.Find("a_unit_container").GetComponentInChildren<Image>();
        GameManager.b_image = GameObject.Find("b_unit_container").GetComponentInChildren<Image>();
        GameManager.c_image = GameObject.Find("c_unit_container").GetComponentInChildren<Image>();


        



        //Vector3 spawnPoint = GameObject.Find("DiceSpawnPoint").transform.position;
        //public static Image a_image;
        //public static Image b_image;
        //public static Image c_image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
