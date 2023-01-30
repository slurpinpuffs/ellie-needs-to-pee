using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    protected Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isRunning = false;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }

    void FixedUpdate(){
        //Physics calculations
        Move();
    }

    public virtual void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y !=0){
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public virtual void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate(){
        if(moveDirection.magnitude > 0.1){
            anim.SetBool("Running", true);
            isRunning = true;
        }else{
            anim.SetBool("Running", false);
            isRunning = false;
        }

        if(moveDirection.x < 0){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }

        if(isRunning == false){
            if(lastMoveDirection.x < 0){
                spriteRenderer.flipX = true;
            }else{
                spriteRenderer.flipX = false;
            }
        }
    }
}
