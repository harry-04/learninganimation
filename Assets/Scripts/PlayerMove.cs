using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed = 8f;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.SetBool("walk_left", true);
        }
        else
        {
            anim.SetBool("walk_left", false);
        }

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            anim.SetBool("walk_right", true);
        }
        else
        {
            anim.SetBool("walk_right", false);
        }

    }
}
