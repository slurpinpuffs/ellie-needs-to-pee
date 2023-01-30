using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfObjectiveObject : InteractableObject
{
    [SerializeField] private SceneManager sm;
    [SerializeField] private GameObject shelf;
    [SerializeField] private PlayerMovement playerController;

    protected override void OnInteract(){
        if(!z_Interacted){
            z_Interacted = true;
            sm.Activate(shelf);
            playerController.enabled = false;
            playerController.rb.velocity = new Vector2(0, 0);
        }
    }
}
