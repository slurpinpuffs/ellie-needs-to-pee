using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UITimer timer;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] DialogueManager dm;

    void Awake(){
        timer = GetComponent<UITimer>();
    }

    void Start(){
        dm.EndDialogue();
        StartCoroutine(DialogueEvents());
    }

    public IEnumerator DialogueEvents(){
        yield return new WaitUntil(() => timer.timeElapsed > 5f);
        StartCoroutine(TriggerDialogue());
        yield return new WaitForSeconds(6);
        StartCoroutine(NextDialogue());
    }

    public IEnumerator TriggerDialogue(){
        dm.StartDialogue(dialogue);
        yield return new WaitForSeconds(5);
        dm.EndDialogue();
    }

    public IEnumerator NextDialogue(){
        dm.DisplayNextSentence();
        yield return new WaitForSeconds(5);
        dm.EndDialogue();
    }
}
