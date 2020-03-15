using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    
    [SerializeField] 
    [Range(0f, 5f)] float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    private void moveLeft(){
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }
}
