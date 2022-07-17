using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDice : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Spawn " + spawnItem.name);    
        //    Spawn();
        //}
        if (GameManager.canSpawn)
        {
            Debug.Log("Spawn " + spawnItem.name);
            Spawn();
            GameManager.canSpawn = false;
        }
    }


    public void Spawn()
    {

        //Debug.Log(GameManager.a_image.sprite.name
        //    + " / " + GameManager.b_image.sprite.name
        //    + " / " + GameManager.c_image.sprite.name);
        if (GameManager.total_a_units != 0)
        {
            MakeDice(GameManager.a_image.sprite.name);
            GameManager.total_a_units--;
        }
        else if (GameManager.total_b_units != 0)
        {
            MakeDice(GameManager.b_image.sprite.name);
            GameManager.total_b_units--;
        }
        else if (GameManager.total_c_units != 0)
        {
            MakeDice(GameManager.c_image.sprite.name);
            GameManager.total_c_units--;
        }

    }
    public void MakeDice(string diceType)
    {

        Vector3 spawnPoint = GameObject.Find("DiceSpawnPoint").transform.position;
        GameObject newObj = Instantiate(spawnItem, spawnPoint, Quaternion.identity);
        newObj.transform.parent = GameObject.Find("DiceSpawnPoint").transform;
        newObj.transform.position = spawnPoint;
        newObj.tag = "Die";

        MeshRenderer objMat = newObj.GetComponent<MeshRenderer>();
        Material diceMat = Resources.Load("Materials/d6/" + diceType, typeof(Material)) as Material;
        objMat.material = diceMat;
        
        


        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        newObj.transform.localScale = new Vector3(.3f, .3f, .3f);
    }
}
