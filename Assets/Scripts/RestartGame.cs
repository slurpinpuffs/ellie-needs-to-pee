using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
