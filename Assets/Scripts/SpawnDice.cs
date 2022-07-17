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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawn");    
            Spawn();
        }
    }


    public void Spawn()
    {
        Vector3 spawnPoint = GameObject.Find("DiceSpawnPoint").transform.position;
        GameObject newObj = Instantiate(spawnItem, spawnPoint, Quaternion.identity);
        newObj.transform.parent = GameObject.Find("DiceSpawnPoint").transform;
        newObj.transform.position = spawnPoint;
        newObj.tag = "Die";


        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        newObj.transform.localScale = new Vector3(.3f, .3f, .3f);
    }
}
