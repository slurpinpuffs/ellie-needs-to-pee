using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveTextController : MonoBehaviour
{

    [SerializeField] TMP_Text objectiveText;

    public void setObjectiveText(string newText){
        objectiveText.text = newText;
    }
}
