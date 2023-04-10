using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkZone : InteractableObject
{
    [SerializeField] SceneManager sm;
    [SerializeField] int totalDialogueCount;
    [SerializeField] BnFControlledDialogueManager cdm;
    [SerializeField] GameObject arrow;

    protected override void Start(){
        cdm = GetComponent<BnFControlledDialogueManager>();
        z_Collider = GetComponent<Collider2D>();
    }

    protected override void OnInteract(){
        if(!z_Interacted){
            z_Interacted = true;
            cdm.enabled = true;
            z_Collider.enabled = false;
            sm.Deactivate(arrow);
        }
    }
}
