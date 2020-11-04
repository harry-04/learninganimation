using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed = 3f;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x); //refers to the animator parameter "Horizontal" and picks to move in the x axis
        anim.SetFloat("Vertical", movement.y);   //refers to the animator parameter "Vertical" and picks to move in the y axis
        anim.SetFloat("Magnitude", movement.magnitude);

        if (movement.magnitude > 3.0f)
        {
            movement.Normalize();
        }

        transform.position = transform.position + movement * Time.deltaTime * moveSpeed;

        

        
    }



    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // check for diagonal movement
        {
            //limit movement diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

    }
}
