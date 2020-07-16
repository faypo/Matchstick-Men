using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    Animator anima;

    public float jumpForce;
    public float walkForce;
    public float maxWalkSpeed;

    private void Start()
    {
        this.rigidbody2 = GetComponent<Rigidbody2D>();
        this.anima = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && this.rigidbody2.velocity.y == 0)
        {
            this.rigidbody2.AddForce(transform.up * this.jumpForce);

        }


        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigidbody2.velocity.x);

        if(speedx < this.maxWalkSpeed)
        {
            this.rigidbody2.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //this.anima.speed = speedx / 2.0f;
        if (speedx == 0)
        {
            this.anima.speed = speedx;
        }
        else if (speedx != 0)
        {
            this.anima.speed = 1;
        }
    }
}
