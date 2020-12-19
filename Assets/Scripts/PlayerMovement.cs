using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("It's working!!");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("your key is UpArrow");
        }
    }
}
