using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBasketWinArea : BasketWinArea
{
    [SerializeField] private GameObject timer;

    protected override IEnumerator getItem(){
        yield return new WaitForSeconds(1);
        playerController.enabled = true;
        StartCoroutine(shelfObjective.EndingDialogue());
        sm.Activate(timer);
        sm.Deactivate(shelf);
    }
}
