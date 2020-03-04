using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour

{
    [SerializeField] int breakableBlocks; //Seriealized for debugging

    //cached references
    SceneLoader sceneLoader;

    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks(){
        breakableBlocks ++;
    }

    public void BlockBroken(){
        breakableBlocks --;
        if(breakableBlocks <= 0){
            sceneLoader.NextScene();
        }
    }
}
