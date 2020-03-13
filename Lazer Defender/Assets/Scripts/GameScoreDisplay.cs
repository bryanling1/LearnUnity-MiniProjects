using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreDisplay : MonoBehaviour
{
    // Update is called once per frame

    //Cached references
    TextMeshProUGUI textBox;
    GameScore gameScore;

    void Start(){
        textBox = GetComponent<TextMeshProUGUI>();
        gameScore = FindObjectOfType<GameScore>();
    }
    void Update()
    {
        displayScore();
    }

    private void displayScore(){
        textBox.SetText(gameScore.getScore().ToString());
    }
}
