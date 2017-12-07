using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;

    bool jumping = false;


    public float RunSpeed = 10f;

	void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        float speed = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = -1f;
        }
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (speed > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(speed < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!jumping)
            {
                jumping = true;
                animator.SetBool("Jumping", true);
                rb.velocity += Vector2.up * 12f;
            }
        }

        rb.position += Vector2.right * speed * Time.deltaTime * RunSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumping)
        {
            if (collision.collider.tag == "Ground") ;
            {
                jumping = false;
                animator.SetBool("Jumping", false);
            }
        }
    }
}
