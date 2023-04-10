using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BnFControlledDialogueManager : MonoBehaviour
{
    [SerializeField] private SceneManager sm;
    [SerializeField] BackAndForthDialogue controlledDialogue;
    [SerializeField] Animator anim;
    private Queue<string> sentences;
    private Queue<string> names;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] PlayerMovement playerController;
    [SerializeField] UITimer timer;
    [SerializeField] GameObject avatar1;
    [SerializeField] GameObject avatar2;
    [SerializeField] string person1 = "Ellie";
    [SerializeField] string person2;

    public virtual void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
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

    public void StartDialogue(BackAndForthDialogue dialogue){
        anim.SetBool("IsOpen", true);

        sentences.Clear();
        names.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        foreach(string name in dialogue.names){
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        anim.SetBool("IsOpen", true);
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        nameText.text = name;

        if(name == person1){
            sm.Activate(avatar1);
            sm.Deactivate(avatar2);
        }else if(name == person2){
            sm.Deactivate(avatar1);
            sm.Activate(avatar2);
        }
    }

    public void EndDialogue(){
        sm.Activate(avatar1);
        sm.Deactivate(avatar2);
        anim.SetBool("IsOpen", false);
        playerController.enabled = true;
        timer.isActive = true;
        enabled = false;
    }
}

