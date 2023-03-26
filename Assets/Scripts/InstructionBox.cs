using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBox : InteractableObject
{
    protected GameObject self;

    protected override void Start(){
        z_Collider = GetComponent<Collider2D>();
        self = this.gameObject;
    }

    protected override void OnInteract(){
        if(!z_Interacted){
            z_Interacted = true;
            self.SetActive(false);
        }
    }
}
