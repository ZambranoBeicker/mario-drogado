using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour


{

    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
			body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("It's working!!");

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("The key 'W' was successfully pressed");
            body.velocity = Vector2.up * 10;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("The key 'W' was successfully pressed");
            body.velocity = Vector2.right * 10;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("The key 'W' was successfully pressed");
            body.velocity = Vector2.left * 10;
        }
        //if (Input.GetKey(KeyCode.S))
        //{
            //Debug.Log("The key 'W' was successfully pressed");
            //body.velocity = Vector2.down * 10;
        //}
    }
}
