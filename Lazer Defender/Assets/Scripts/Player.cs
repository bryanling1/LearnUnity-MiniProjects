﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // config
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] float lazerVelocity = 10f;
    [SerializeField] float lazerDelay = 0.5f;

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
                GameObject lazer = Instantiate(lazerPrefab, transform.position, Quaternion.identity) as GameObject;
                lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, lazerVelocity);
                yield return new WaitForSeconds(lazerDelay);
            }
        }

}
