using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadStartScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Debug.Log("hello wrold");
    }

    public void loadFirstLevel(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void loadNextScene(){
        int nextLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }

    public void loadLoseScene(){
        StartCoroutine(loseScene());
    }

    IEnumerator loseScene(){
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
    
}
