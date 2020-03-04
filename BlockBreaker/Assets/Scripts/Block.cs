using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip blockDestorySound;
    [SerializeField] GameObject blockBreakFX;
    [SerializeField] int maxBlockHits = 1;
    [SerializeField] Sprite[] hitBlockSprites; 

    //states
    [SerializeField] int blockHits = 0; 

    //cached references
    Level level;
    GameSession GameStatus;

    void Start(){
        level = FindObjectOfType<Level>();
        GameStatus = FindObjectOfType<GameSession>();
        if(tag == "breakable"){
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(tag == "breakable"){
            AudioSource.PlayClipAtPoint(blockDestorySound, Camera.main.transform.position);
            onBlockHit();
        }
    }
    private void destoryBlockFX(){
        GameObject particles = Instantiate(blockBreakFX, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }

    private void onBlockHit(){
        blockHits ++;  
        if (blockHits == maxBlockHits){
            destroyBlock();
        }else{
            GetComponent<SpriteRenderer>().sprite = hitBlockSprites[blockHits - 1];
        }
    }

    private void destroyBlock(){
        Destroy(gameObject);
        level.BlockBroken();
        GameStatus.addToScore();
        destoryBlockFX();
    }


}
