using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 250f;
    private bool isGrounded = false;
    bool ableToDoubleJump;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
            isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || ableToDoubleJump))
        {
            if (isGrounded)
            {
                ableToDoubleJump = true;
            }
            else if (ableToDoubleJump)
            {
                ableToDoubleJump = false;
            }
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
