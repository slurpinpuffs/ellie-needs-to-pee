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
    //DialogueBox animator
    [SerializeField] Animator animator;
    [SerializeField] int waitTime = 3;

    void Awake(){
        timer = GetComponent<UITimer>();
    }

    public virtual void Start(){
        StartCoroutine(DialogueEvents());
    }

    public IEnumerator DialogueEvents(){
        yield return new WaitUntil(() => timer.timeElapsed > 3.5f);
        StartCoroutine(TriggerDialogue());
        StartCoroutine(NextDialogue());
    }

    public IEnumerator TriggerDialogue(){
        if(animator.GetBool("IsOpen") == true){
            yield return new WaitUntil(() => animator.GetBool("IsOpen") == false);
        }
        dm.StartDialogue(dialogue);
        yield return new WaitForSeconds(waitTime);
        dm.EndDialogue();
    }

    public IEnumerator NextDialogue(){
        if(animator.GetBool("IsOpen") == true){
            yield return new WaitUntil(() => animator.GetBool("IsOpen") == false);
        }
        dm.DisplayNextSentence();
        yield return new WaitForSeconds(waitTime);
        dm.EndDialogue();
    }

    public IEnumerator NextHalfDialogue(){
        if(animator.GetBool("IsOpen") == true){
            yield return new WaitUntil(() => animator.GetBool("IsOpen") == false);
        }
        dm.DisplayNextSentence();
        yield return new WaitForSeconds(waitTime/2);
        dm.EndDialogue();
    }
}
