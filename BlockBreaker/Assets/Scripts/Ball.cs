using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle mainPaddle; 
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballCollisionSounds;
    [SerializeField] float randomVelocityFactor = 1.2f;
    // Start is called before the first frame update
    Vector2 diffVector;
    bool hasStarted = false;

    // Cached references
    AudioSource ballAudioSource;
    Rigidbody2D ballVelocityReference;

    void Start()
    {   
        diffVector = transform.position - mainPaddle.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        ballVelocityReference = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
       if(!hasStarted){
           holdBall();
           launchBall();
       }
    }

    private void holdBall(){
        Vector2 ballPos = new Vector2(mainPaddle.transform.position.x, mainPaddle.transform.position.y);
        transform.position = diffVector + ballPos;
    }

    private void launchBall(){
        if(Input.GetMouseButtonDown(0) && !hasStarted){
            Vector2 launchAngel = new Vector2(xPush, yPush);
            GetComponent<Rigidbody2D>().velocity = launchAngel;
            hasStarted = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(true == hasStarted){
            AudioClip clip = ballCollisionSounds[UnityEngine.Random.Range(0, ballCollisionSounds.Length)];
            ballAudioSource.PlayOneShot(clip);
            Vector2 velocityTweek = new Vector2(
                UnityEngine.Random.Range(0, randomVelocityFactor),
                 UnityEngine.Random.Range(0, randomVelocityFactor)
            );
            ballVelocityReference.velocity += velocityTweek;
        }
    }

    public bool isGameStarted(){
        return hasStarted;
    }
}
