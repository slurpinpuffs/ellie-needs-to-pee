using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void Activate(GameObject shelf){
        shelf.SetActive(true);
    }

    public void Deactivate(GameObject shelf){
        shelf.SetActive(false);
    }

}
