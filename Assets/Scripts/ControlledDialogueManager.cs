using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlledDialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue controlledDialogue;
    [SerializeField] Animator anim;
    private Queue<string> sentences;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] PlayerMovement playerController;
    [SerializeField] UITimer timer;

    public virtual void Start()
    {
        sentences = new Queue<string>();
        playerController.enabled = false;
        playerController.rb.velocity = new Vector2(0, 0);
        timer.isActive = false;
        StartDialogue(controlledDialogue);
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            DisplayNextSentence();
        }
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
        playerController.enabled = true;
        timer.isActive = true;
        enabled = false;
    }
}
