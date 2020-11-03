using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed = 8f;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            anim.SetBool("walk_left", true);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);  
        }
        else
        {
            anim.SetBool("walk_left", false);
        }

        if (Input.GetKey("d"))
        {
            anim.SetBool("walk_right", true);
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        }
        else
        {
            anim.SetBool("walk_right", false);
        }

    }
}
