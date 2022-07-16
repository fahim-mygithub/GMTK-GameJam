using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
//    [SerializeField]
//    private Vector3 destination;
//    [SerializeField]
//    private float speed;
//    // Start is called before the first frame update

    [SerializeField]
    private float timer;

    private float currentTime;
    private bool goLeft = false;




    private Transform myTransform;
    void Start()
    {

        myTransform = GetComponent<Transform>();

        goLeft = true;
        currentTime = 0;




    }

    // Update is called once per frame
    void Update()
    {

        if (goLeft)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            goLeft = !goLeft;
            currentTime = timer;
        }




        //Debug.Log(currentTime);


    }
    private void MoveLeft()
    {
        Vector3 transPos = myTransform.position;
        Vector3 leftMove =
            new Vector3(transPos.x + .01f, transPos.y, transPos.z);
        myTransform.position = leftMove;

        Vector3 transEAngle = myTransform.eulerAngles;
        Vector3 clockwiseRotate =
            new Vector3(transEAngle.x, transEAngle.y, transEAngle.z - .5f);
        myTransform.eulerAngles = clockwiseRotate;
    }
    //hastily copied and reversed :^)
    private void MoveRight()
    {
        Vector3 transPos = myTransform.position;
        Vector3 leftMove =
            new Vector3(transPos.x - .01f, transPos.y, transPos.z);
        myTransform.position = leftMove;

        Vector3 transEAngle = myTransform.eulerAngles;
        Vector3 clockwiseRotate =
            new Vector3(transEAngle.x, transEAngle.y, transEAngle.z + .5f);
        myTransform.eulerAngles = clockwiseRotate;
    }


}
