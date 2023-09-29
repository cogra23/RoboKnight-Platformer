using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private bool canJump = true;
    private Animator anim;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    // [SerializeField] public CoinManager cm;

    void Start ()
    {
        respawnPoint = transform.position;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Horizontal movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flips character
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        // Jumping if the player can jump and presses the space key.
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            canJump = false; // Set canJump to false to prevent further jumps until grounded.
        }

        anim.SetBool("run", horizontalInput != 0);
        //anim.SetBool("grounded", grounded);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded upon collision with the ground.
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // The player is grounded and can jump again.
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }

        // if (collision.tag == "Coin")
        // {
        //     Destroy(gameObject);
        // }
    }

    // private void OnTriggerEnter2DCoin(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Coin"))
    //     {
    //         Destroy(other.gameObject);
    //         // cm.coinCount++;
    //     }
    // }
}
