using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] SceneManager sm;
    [SerializeField] Animator anim;
    [SerializeField] GameObject instructionBox;
    [SerializeField] GameObject eventManager;
    [SerializeField] PlayerMovement playerController;

    void Update()
    {
        if (Input.GetKeyDown("space")){
            anim.SetTrigger("Start");
            StartCoroutine(Reactivate());
        }
    }

    public IEnumerator Reactivate(){
        yield return new WaitForSeconds(1);
        sm.Activate(instructionBox);
        sm.Activate(eventManager);
    }

    void Start(){
        playerController.enabled = false;
    }
}
