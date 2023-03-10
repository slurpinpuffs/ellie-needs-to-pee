using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomObjectiveObject : InteractableObject
{
    [SerializeField] SceneManager sm;
    [SerializeField] ControlledDialogueManager dm;
    [SerializeField] private PlayerMovement playerController;
    [SerializeField] GameObject nextShelfObjective;
    [SerializeField] protected ObjectiveTextController objectiveText;
    [SerializeField] protected string nextListItem;

    protected override void Start(){
        z_Collider = GetComponent<Collider2D>();
        dm = GetComponent<ControlledDialogueManager>();
    }

    protected override void OnInteract(){
        if(!z_Interacted){
            z_Interacted = true;
            playerController.enabled = false;
            objectiveText.setObjectiveText(nextListItem);
            playerController.rb.velocity = new Vector2(0, 0);
            dm.enabled = true;
            z_Collider.enabled = false;
            sm.Activate(nextShelfObjective);
        }
    }
}
