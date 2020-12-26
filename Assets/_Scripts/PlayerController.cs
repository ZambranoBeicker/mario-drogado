using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    //private CapsuleCollider2D collider2d;
    private BoxCollider2D box2D;
    private float speed = 500f, runSpeed = 1000f, jumpSpeed = 45000f, climp = 10f;
    public float distanceToGround = 0.1f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
        //collider2d = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.up * climp * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, climp * Time.deltaTime));
        }
        if (BoolJump() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Force);
        }
    }
    //public LayerMask groundLayer;
    bool BoolJump()
    {
        Vector2 capsuleBottom = new Vector2(box2D.bounds.center.x, box2D.bounds.min.y);
        bool grounded = Physics2D.IsTouchingLayers(box2D);
        return grounded;
    }

}
