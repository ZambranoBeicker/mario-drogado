using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box2D;
    private SpriteRenderer mario;
    [SerializeField] private float speed = 480f,runSpeed = 1000f, jumpSpeed = 280f, climp = 2.5f;
    //private float distanceToGround = 0.1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
        mario = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Walking", 1f);
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            mario.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("Walking", -1f);
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
            mario.flipX = false;
        }
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, climp);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, -climp);
        }
        if (Input.GetButton("Sprint") && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) || Input.GetButton("Sprint") && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            Runner();
        }

        //para evitar errores mas grandes es necesario movelo a FixedUpdate o establecer un limite en los cuadros por segundo
        /*if (BoolJump() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce = new Vector2(0f, jumpSpeed);
        }*/
    }
    private void FixedUpdate()
    {
        //TODO: reparar el salto e Input
        if (BoolJump() && Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
        }
    }
    private bool BoolJump()
    {
        //Posibles modificaciones a un Void y encapsulamiento
        Vector2 capsuleBottom = new Vector2(box2D.bounds.center.x, box2D.bounds.min.y);
        bool grounded = Physics2D.IsTouchingLayers(box2D);
        return grounded;
    }
    private void Runner()
    {
        //TODO: Boton para Correr en alfa, es necesario que vuelva a su valor inicial una vez el boton deje de ser precionado
        Vector2 runnerVector = new Vector2(runSpeed, jumpSpeed + 2);
    }
}
