using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfObjectiveObject : InteractableObject
{
    [SerializeField] private SceneManager sm;
    [SerializeField] private GameObject shelf;
    [SerializeField] private PlayerMovement playerController;
    [SerializeField] GameObject dialogueBox;
    //Event dialogue manager (seperate from normal/timed dialogue box manager)
    [SerializeField] DialogueManager dm;
    //Dialogue box animator
    [SerializeField] Animator animator;
    [SerializeField] GameObject nextShelfObjective;
    [SerializeField] int startDialogueCount = 1;
    [SerializeField] Dialogue dialogue;

    protected override void OnInteract(){
        if(!z_Interacted){
            z_Interacted = true;
            sm.Activate(shelf);
            playerController.enabled = false;
            playerController.rb.velocity = new Vector2(0, 0);
            StartCoroutine(BeginningDialogue(startDialogueCount));
        }
    }

    public IEnumerator BeginningDialogue(int count){
        if(animator.GetBool("IsOpen") == true){
            yield return new WaitUntil(() => animator.GetBool("IsOpen") == false);
        }


        dm.StartDialogue(dialogue);
        yield return new WaitForSeconds(3);

        for(int i = 1; i < count; i++){
            dm.DisplayNextSentence();
            yield return new WaitForSeconds(3);
        }
        
        dm.EndDialogue();
    }

    public IEnumerator EndingDialogue(int count){
        if(animator.GetBool("IsOpen") == true){
            yield return new WaitUntil(() => animator.GetBool("IsOpen") == false);
        }
        StartCoroutine(dm.DelayedDialogue(count));
        sm.Activate(nextShelfObjective);
        transform.position = new Vector3(-1300f, -500f, 8.6f);
    }

}
