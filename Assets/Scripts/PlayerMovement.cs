using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }

    private void Die(){
        Debug.Log("mori :(");
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Spike")){
            Die();
        }
    }
}
