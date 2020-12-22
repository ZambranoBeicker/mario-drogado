using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour


{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    float moveXAxis = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        moveXAxis = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(moveXAxis);
    }

    void FixedUpdate()
    {
        Debug.Log(moveXAxis * Time.fixedDeltaTime);
        controller.Move(moveXAxis * Time.fixedDeltaTime, false, false);

    }
}
