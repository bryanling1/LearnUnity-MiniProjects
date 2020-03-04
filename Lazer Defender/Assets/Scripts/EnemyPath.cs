using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    //config
    CreateConfig waveConfig;
    List<Transform> EnemyWaypoints;

    //state
    int waypointIndex = 0;
    // Start is called before the first frame update

    public void setWaveConfigForEnemey(CreateConfig waveConfig){
        this.waveConfig = waveConfig;
    }
    void Start()
    {
        EnemyWaypoints = waveConfig.getWaypoints();
        transform.position = EnemyWaypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move(){
        if(waypointIndex <= EnemyWaypoints.Count - 1){
            var moveSpeed = waveConfig.getMoveSpeed() * Time.deltaTime;
            var moveTarget = EnemyWaypoints[waypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, moveTarget, moveSpeed);
            if(transform.position == moveTarget){
                waypointIndex ++;
            }
        }else{
            Destroy(gameObject);
        }
    }
}
