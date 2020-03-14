using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string loadingText = "loading";
    [SerializeField] int dots = 3;
    
    string currentText;
    void Start()
    {
        currentText = loadingText;
        StartCoroutine(loadDotsAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator loadDotsAnimation(){
        int i = 0;
        while(true){
            i++;
            displayText(currentText);
            if(i>dots){
                currentText = loadingText;
                i = 0; 
            }else{
                currentText += ".";
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void displayText(string s){
        GetComponent<Text>().text = currentText; 
    }


}
