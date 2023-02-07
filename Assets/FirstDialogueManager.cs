using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstDialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue firstDialogue;
    [SerializeField] Animator anim;
    [SerializeField] int waitTime = 3;
    private Queue<string> sentences;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;

    public virtual void Start()
    {
        sentences = new Queue<string>();
        StartCoroutine(StartFirstDialogue());
    }

    public void StartDialogue(Dialogue dialogue){
        anim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        anim.SetBool("IsOpen", true);
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue(){
        anim.SetBool("IsOpen", false);
    }

    public IEnumerator StartFirstDialogue(){
        StartDialogue(firstDialogue);
        yield return new WaitForSeconds(waitTime);
        EndDialogue();
        DisplayNextSentence();
        yield return new WaitForSeconds(waitTime);
        EndDialogue();
        DisplayNextSentence();
        yield return new WaitForSeconds(waitTime);
        EndDialogue();
        DisplayNextSentence();
        yield return new WaitForSeconds(waitTime);
        EndDialogue();
        DisplayNextSentence();
        yield return new WaitForSeconds(waitTime);
        EndDialogue();
    }
}
