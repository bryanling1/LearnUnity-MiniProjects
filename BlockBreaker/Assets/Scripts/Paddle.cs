using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float xLowerLimit = 0f;
    [SerializeField] float xUpperLimit = 14.06f;
    // Cached References
    GameSession gameSessionRef;
    Ball ballRef;
    void Start()
    {
        gameSessionRef = FindObjectOfType<GameSession>();
        ballRef = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getXPos(), xLowerLimit, xUpperLimit);
        transform.position = paddlePos;
    }

    private float getXPos(){
        if(gameSessionRef.isAutoPlayOn() && ballRef.isGameStarted()){
            return ballRef.transform.position.x;
        }
        else{
            return Input.mousePosition.x / Screen.width * screenWidth;;
        }
    }
}
