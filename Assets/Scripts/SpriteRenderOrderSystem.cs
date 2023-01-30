using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrderSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach(SpriteRenderer renderer in renderers){
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
        }
    }
}
