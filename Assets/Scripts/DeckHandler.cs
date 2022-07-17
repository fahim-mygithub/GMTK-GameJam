using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckHandler : MonoBehaviour
{
    public Image a_image;
    public Image b_image;
    public Image c_image;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.a_image = a_image;
        GameManager.b_image = b_image;
        GameManager.c_image = c_image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
