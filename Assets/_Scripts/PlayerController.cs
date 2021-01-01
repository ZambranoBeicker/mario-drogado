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
    [SerializeField, Range(1f, 1000f), Tooltip("Velocidades Del Player")]
    private float speed = 480f,runSpeed = 1000f, jumpSpeed = 380f, climp = 2.5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
        mario = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0f));
            mario.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0f));
            mario.flipX = false;
        }
        //TODO: Añadir una Funcion en OntriggerEnter2D en Raiz ascendente(puede violar la gravedad al precionar el botton W y desactivarlo al saltar)
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0f, climp);
        }
        //TODO: Añadir una Funcion en OntriggerEnter2D en Raiz ascendente(puede violar la gravedad al precionar el botton W y desactivarlo al saltar)
        //y para entrar a un tuvo(ignora las colisiones y la gravedad)
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0f, -climp);
        }
        if (Input.GetButton("Sprint") && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) || Input.GetButton("Sprint") && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            Runner();
        }
        if (BoolJump() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpSpeed));
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector2(0f, 10f));
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
    //TODO: añadir Funcion de nadar, vida y mario pequeño
}
