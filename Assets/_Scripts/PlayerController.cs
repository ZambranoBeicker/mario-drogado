using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box2D;
    private float speed = 500f, runSpeed = 1000f, jumpSpeed = 7.5f, climp = 10f;
    public float distanceToGround = 0.1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

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
        if (Input.GetButton("Sprint") && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) || Input.GetButton("Sprint") && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            Runner();
        }

        //El salto al multiplicarlo con el Time.deltaTime se va a la mrd, el Time.deltaTime es un comando importante para que no varien las fisicas en un algun dispositovo con potencia extremadamente baja o una con mucha
        //Aun asi al aplicarlo al salto este hace saltos extraños, la unica solucion que veo es limitar los FPS
        /*if (BoolJump() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0f, jumpSpeed);
        }*/
    }
    private void FixedUpdate()
    {
        //TODO reparar el salto
        if (BoolJump() && Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(0f, jumpSpeed);
        }
    }
    bool BoolJump()
    {
        Vector2 capsuleBottom = new Vector2(box2D.bounds.center.x, box2D.bounds.min.y);
        bool grounded = Physics2D.IsTouchingLayers(box2D);
        return grounded;
    }
    void Runner()
    {
        Vector2 runnerVector = new Vector2(runSpeed, jumpSpeed + 2);
    }
}
