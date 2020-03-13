using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int pointsPerEnemyDestroyed = 100;
    [SerializeField] int score = 0;

    void Awake() {
        int sessions = FindObjectsOfType(GetType()).Length;
        if (sessions > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    public void updateScoreOnEnemyKill(){
        score += pointsPerEnemyDestroyed;
    }


    public int getScore(){
        return score;
    }


}
