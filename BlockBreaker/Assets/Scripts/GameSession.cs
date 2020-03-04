using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config
    [Range(0.1f, 10f)][SerializeField] float timeScale = 1f;
    [SerializeField] int pointsAddWhenBlockBreaks = 10;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] bool AutoPlayOn = false;

    // state variables
    [SerializeField] int score = 0;

    private void Awake() {
        int numberOfGameStatusses = FindObjectsOfType<GameSession>().Length;
        if(numberOfGameStatusses > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start() {
        scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }

    public void addToScore(){
        score += pointsAddWhenBlockBreaks;
        scoreDisplay.text = score.ToString();
    }
    public void restartGame(){
        Destroy(gameObject);
    }

    public bool isAutoPlayOn(){
        return AutoPlayOn;
    }
}
