using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchoredInstructionBox : InstructionBox
{
    [SerializeField] GameObject message;

    protected override void Start(){
        self = message;
        z_Collider = GetComponent<Collider2D>();
    }
}
