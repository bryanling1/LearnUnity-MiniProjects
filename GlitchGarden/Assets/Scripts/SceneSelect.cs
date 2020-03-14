using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{

    [SerializeField] float timeToLoad = 4f;
    int currentScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(currentScene == 0){
            StartCoroutine(finishLoadingSplash());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextLevel(){
        int currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(currentScene);
    }

    IEnumerator finishLoadingSplash(){
        yield return new WaitForSeconds(timeToLoad);
        loadNextLevel();
    }


}
