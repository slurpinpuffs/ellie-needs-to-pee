using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackAndForthDialogue
{
    [TextArea(3, 10)]
    public string[] names;
    public string[] sentences;
}
