using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : PlayerMovement
{
    [SerializeField] private ItemController controller;
    private Vector3 startPosition = new Vector3();

    void Start(){
        startPosition = transform.position;
    }

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate(){
        //Physics calculations
        Move();
    }

    public override void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, 0f).normalized;
        if(Input.GetAxisRaw("Release") > 0.1){
            rb.gravityScale = 1.0f;
            controller.enabled = false;
        }
    }

    public void resetPosition(){

        //Resets object's position, gravity, rotation, and restarts the player controller
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        rb.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        transform.position = startPosition;
        controller.enabled = true;
    }
}
