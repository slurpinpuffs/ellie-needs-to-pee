using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject shelfScene1;
    // Start is called before the first frame update
    void Start()
    {
        Deactivate(shelfScene1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(GameObject shelf){
        shelf.SetActive(true);
    }

    public void Deactivate(GameObject shelf){
        shelf.SetActive(false);
    }

}
