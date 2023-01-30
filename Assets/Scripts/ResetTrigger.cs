using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : InteractBox
{
    private Rigidbody2D collidedRb;
    private ItemController controller;
    private bool isTriggered = false;

    protected override void OnCollision(GameObject collidedObject){
        if(collidedObject.tag == "Item"){
            //Gets RigidBody and controller of collided object
            collidedRb = collidedObject.GetComponent<Rigidbody2D>();
            controller = collidedObject.GetComponent<ItemController>();
            StartCoroutine(resetObject());
        }
    }

    IEnumerator resetObject(){
        //Runs check to see if this event was triggered already. If not triggered, runs and marked as triggered until the item is out of the trigger zone.
        if(isTriggered == false){
            isTriggered = true;

            //Wait 1 sec
            yield return new WaitForSeconds(1);

            //Resets object's position, gravity, rotation, and restarts the player controller
            controller.resetPosition();
            isTriggered = false;
        }
    }
}
