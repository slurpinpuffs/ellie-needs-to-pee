using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : InteractBox
{
    protected bool z_Interacted = false;
    
    protected override void OnCollision(GameObject collidedObject){
        if(collidedObject.tag == "Player"){
            if(Input.GetKey(KeyCode.E)){
                OnInteract();
            }
        }
    }

    protected virtual void OnInteract(){
        if(!z_Interacted){
            z_Interacted = true;
            Debug.Log("Interacted with " + name);
        }
    }
}
