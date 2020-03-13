using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    // Start is called before the first frame updat
    void Awake(){
        int sessions = FindObjectsOfType(GetType()).Length;
        if(sessions > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }



}
