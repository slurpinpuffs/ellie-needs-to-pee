using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInstructionBox : MonoBehaviour
{

    GameObject self;


    void Start()
    {
        self = this.gameObject;
    }


    void Update()
    {
        if(Input.GetKeyDown("space")){
            self.SetActive(false);
        }
    }
}
