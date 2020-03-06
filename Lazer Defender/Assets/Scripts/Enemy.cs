using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 500;
    [SerializeField] GameObject projectileObject; 
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float lowerTimeBetweenShots = 0.5f;
    [SerializeField] float upperTimeBetweenShots = 2f;

    float timer;
    void Start()
    {
        timer = UnityEngine.Random.Range(lowerTimeBetweenShots, upperTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        shootProjectiles();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        processHit(damageDealer);
    }

    private void processHit(DamageDealer damageDealer){
        health -= damageDealer.getDamage();
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    private void shootProjectiles(){
        timer -= Time.deltaTime;
        if(timer <= 0f){   
            GameObject lazer = Instantiate(projectileObject, 
            gameObject.transform.position, 
            Quaternion.identity) as GameObject;
            lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            timer = UnityEngine.Random.Range(lowerTimeBetweenShots, upperTimeBetweenShots);
        }
    }
}
