using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    Image peeBar;
    [SerializeField] public float maxTime = 5f;
    public float timeElapsed;
    [SerializeField] TMP_Text peeText;

    // Start is called before the first frame update
    void Start()
    {
        peeBar = GetComponent<Image> ();
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed < maxTime){
            timeElapsed += Time.deltaTime;
            peeBar.fillAmount = timeElapsed/maxTime;
        }else{
            Time.timeScale = 0;
        }
        peeText.text = (maxTime - timeElapsed).ToString("f1");
    }
}
