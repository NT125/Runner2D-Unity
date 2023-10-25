using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        Debug.Log(playerAnimator.GetBool("isJumping"));
        Debug.Log(playerAnimator.GetBool("isFalling"));
    }

    // Update is called once per frame
    void Update()
    {
        checkJump();
        checkFall();
    }

    private void checkJump()
    {
        if (playerRB.velocity.y > 0f)
        {
            playerAnimator.SetBool("isJumping", true);
        }
        else
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }

    private void checkFall()
    {
        if (playerRB.velocity.y < 0f)
        {
            playerAnimator.SetBool("isFalling", true);
        }
        else
        {
            playerAnimator.SetBool("isFalling", false);
        }
    }
}
