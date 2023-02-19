using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBasketWinArea : BasketWinArea
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject bathroom;

    protected override IEnumerator getItem(){
        yield return new WaitForSeconds(1);
        playerController.enabled = true;
        objectiveText.setObjectiveText(nextListItem);
        StartCoroutine(shelfObjective.EndingDialogue());
        sm.Activate(timer);
        sm.Activate(bathroom);
        sm.Deactivate(shelf);
    }
}
