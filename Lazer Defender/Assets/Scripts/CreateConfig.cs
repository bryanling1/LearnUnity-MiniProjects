using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy Wave Config")]
public class CreateConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.2f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemyPrefab(){ return enemyPrefab; }
    public List<Transform> getWaypoints(){
        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform){
            wayPoints.Add(child);
        }
         return wayPoints;
    }
    public float getTimeBetweenSpans(){ return timeBetweenSpawns; }
    public float getspawnRandomFactor(){ return spawnRandomFactor; }
    public int getNumberofEnemies(){ return numberOfEnemies;}
    public float getMoveSpeed(){ return moveSpeed;}
    
}
