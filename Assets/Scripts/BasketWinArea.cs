using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketWinArea : InteractBox
{
    protected bool gotItem = false;
    [SerializeField] protected SceneManager sm;
    [SerializeField] protected GameObject shelf;
    [SerializeField] protected PlayerMovement playerController;
    [SerializeField] protected ShelfObjectiveObject shelfObjective;
    [SerializeField] protected ObjectiveTextController objectiveText;
    [SerializeField] protected string nextListItem;
    [SerializeField] protected int endDialogueCount = 1;
    [SerializeField] GameObject nextShelfObjective;

    protected override void OnCollision(GameObject collidedObject){
        if(collidedObject.tag == "Item" && gotItem == false){
            StartCoroutine(getItem());
            gotItem = true;
        }
    }

    protected virtual IEnumerator getItem(){
        yield return new WaitForSeconds(1);
        playerController.enabled = true;
        objectiveText.setObjectiveText(nextListItem);
        StartCoroutine(shelfObjective.EndingDialogue(endDialogueCount));
        sm.Activate(nextShelfObjective);
        sm.Deactivate(shelf);
    }
}
