using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed = 8f;
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
        //Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == -1)
        {
            anim.SetBool("walk_left", true);
        }
        else
        {
            anim.SetBool("walk_left", false);
        }

        if (horizontal == 1)
        {
            anim.SetBool("walk_right", true);
        }
        else
        {
            anim.SetBool("walk_right", false);
        }

        if (vertical == -1)
        {
            anim.SetBool("walk_down", true);
        }
        else
        {
            anim.SetBool("walk_down", false);
        }

        if (vertical == 1)
        {
            anim.SetBool("walk_up", true);
        }
        else
        {
            anim.SetBool("walk_up", false);
        }
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
