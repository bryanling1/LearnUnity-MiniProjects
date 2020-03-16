using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    private void moveLeft(){
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }

    public void setMoveSpeed(float speed){
        moveSpeed = speed;
    }
}
