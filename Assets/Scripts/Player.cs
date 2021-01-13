using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpingHeight;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public float speed = 2f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            rigidbody2D.AddForce(new Vector2(0, jumpingHeight));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(speed * -1, rigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.gameOver = true;
        }

        if (collision.gameObject.tag == "Queen")
        {
            gameManager.congrats = true;
        }
    }
}
