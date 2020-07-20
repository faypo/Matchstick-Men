using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    Animator anima;

    public float jumpForce;
    public float walkSpeed;

    private BoxCollider2D myFeet;
    private bool isGround;


    private void Start()
    {

        this.rigidbody2 = GetComponent<Rigidbody2D>();
        this.myFeet = GetComponent<BoxCollider2D>();
        this.anima = GetComponent<Animator>();

    }

    private void Update()
    {
        walk();
        flip();
        jump();
        checkGrounded();
        //attack();
        switchAnimation();
    }

    //private void attack()
    //{
    //    if (Input.GetButtonDown("Attack"))
    //    {
    //        anima.SetTrigger("Attack");
    //    }
    //}


    private void walk()
    {
        float moveDir = Input.GetAxis("Horizontal");


        Vector2 playerVel = new Vector2(moveDir * walkSpeed, rigidbody2.velocity.y);
        rigidbody2.velocity = playerVel;


        bool playerHasXAxisSpeed = Mathf.Abs(rigidbody2.velocity.x) > Mathf.Epsilon;
        anima.SetBool("walk", playerHasXAxisSpeed);

    }

    private void flip()
    {

        bool playerHasXAxisSpeed = Mathf.Abs(rigidbody2.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (rigidbody2.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (rigidbody2.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                Vector2 jumpVec = new Vector2(0.0f, jumpForce);
                rigidbody2.velocity = Vector2.up * jumpVec;
            }
        }
    }

    private void checkGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    private void switchAnimation()
    {
        anima.SetBool("Idie", false);
        if (isGround)
        {
            anima.SetBool("Idie", true);
        }
    }

    #region Animation
    //private void animationWalkLeft()
    //{

    //}
    #endregion

    #region Action
    //private void actionWalkLeft()
    //{

    //}

    //private void actionWalkRight()
    //{

    //}

    //private void actionJumpUp()
    //{

    //}

    //private void actionJumpKeep()
    //{

    //}

    //private void actionJumpDown()
    //{

    //}

    //private void actionAttack()
    //{

    //}
    #endregion

}
