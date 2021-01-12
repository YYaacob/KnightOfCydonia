using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpingHeight;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping", false);

        }
        if(collision.gameObject.tag == "Obstacle")
        {
            gameManager.gameOver = true;
        }
    }
}
