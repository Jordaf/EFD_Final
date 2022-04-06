using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    // Determines the movement speed of our player character
    private float moveSpeed;
    // Determines the height of the players jump
    private float jumpForce;
    // Checks if the player is jumping
    private bool isJumping;
    // Lets player move left and right
    private float moveSideways;
    // Lets player jump
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;
        jumpForce = 7f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveSideways = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate ()
    {
        if (moveSideways > 0.1f || moveSideways < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveSideways * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
