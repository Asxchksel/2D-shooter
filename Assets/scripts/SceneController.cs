using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    public void GotoGame(){
        SceneManager.LoadScene(0);
    }

    public void GotoStart(){
        SceneManager.LoadScene(2);
    }
}
