using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    [SerializeField] SceneManager sm;
    Image peeBar;
    [SerializeField] public float maxTime = 5f;
    public float timeElapsed;
    [SerializeField] TMP_Text peeText;
    [SerializeField] GameObject failScreen;
    public bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        peeBar = GetComponent<Image> ();
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {   if(isActive == true){
            if(timeElapsed < maxTime){
                timeElapsed += Time.deltaTime;
                peeBar.fillAmount = timeElapsed/maxTime;
            }else{
                sm.Activate(failScreen);
                Time.timeScale = 0;
            }
            peeText.text = (maxTime - timeElapsed).ToString("f1");
        }
    }
}
