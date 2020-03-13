using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // config
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int health = 1000;
    [SerializeField] GameObject deathExplosionFX;
    [SerializeField] float deathDuration = 1f;

    [Header("Lazer")]
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] float lazerVelocity = 10f;
    [SerializeField] float lazerDelay = 0.5f;
    [SerializeField] AudioClip fireSound;
    [SerializeField][Range(0,1)] float fireVolume = 1f;

    

    //Cached references
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine holdAndShootRoutine;
    
    // Update is called once per frame
    void Start(){
        setupBoundaries();
    }
    void Update()
    {
        move();
        shoot();
    }

    private void setupBoundaries(){
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void move(){
        
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var xPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var yPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(xPos, yPos);   
    }

    private void shoot(){
        if(Input.GetButtonDown("Fire1")){
            holdAndShootRoutine = StartCoroutine(shootAndHold());
        }

        if(Input.GetButtonUp("Fire1")){
            StopCoroutine(holdAndShootRoutine);
        }
    }

    IEnumerator shootAndHold(){
            while(true){
                AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, fireVolume);
                GameObject lazer = Instantiate(lazerPrefab, transform.position, Quaternion.identity) as GameObject;
                lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, lazerVelocity);
                yield return new WaitForSeconds(lazerDelay);
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        processHit(damageDealer);
    }

    private void processHit(DamageDealer damageDealer){
        health -= damageDealer.getDamage();
        if(health <= 0){
            FindObjectOfType<SceneLoader>().loadLoseScene();
            var explosion = Instantiate(deathExplosionFX, transform.position, transform.rotation) as GameObject;
            Destroy(explosion, deathDuration);
            Destroy(gameObject);
            
        }
    }

    


}
