using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 21f;
    [SerializeField] private float movementSpeed = 3f;
    private Rigidbody2D playerRB;

    // Game Loop
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }

    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerRB.transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerRB.transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Spike"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 11f);
        }
    }
}
