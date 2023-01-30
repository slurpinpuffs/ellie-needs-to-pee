using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketWinArea : InteractBox
{
    private bool gotItem = false;
    [SerializeField] private SceneManager sm;
    [SerializeField] private GameObject shelf;
    [SerializeField] private PlayerMovement playerController;

    protected override void OnCollision(GameObject collidedObject){
        if(collidedObject.tag == "Item" && gotItem == false){
            StartCoroutine(getItem());
            gotItem = true;
        }
    }

    private IEnumerator getItem(){
        yield return new WaitForSeconds(2);
        playerController.enabled = true;
        sm.Deactivate(shelf);
    }
}
