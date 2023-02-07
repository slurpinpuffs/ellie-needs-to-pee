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

    protected override void OnCollision(GameObject collidedObject){
        if(collidedObject.tag == "Item" && gotItem == false){
            StartCoroutine(getItem());
            gotItem = true;
        }
    }

    protected virtual IEnumerator getItem(){
        yield return new WaitForSeconds(1);
        playerController.enabled = true;
        StartCoroutine(shelfObjective.EndingDialogue());
        sm.Deactivate(shelf);
    }
}
