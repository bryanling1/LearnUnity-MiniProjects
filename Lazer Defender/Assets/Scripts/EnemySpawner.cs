using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<CreateConfig> WaveConfigs;
    [SerializeField] bool isLooping = false;
    int startingWave = 0;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do{
            yield return StartCoroutine(spawnAllEnemyWaves());
        }
        while(isLooping);
    }

    private IEnumerator spawnAllEnemyWaves(){
        for (int wave=0; wave < WaveConfigs.Count; wave++){
            yield return StartCoroutine(SpawnAllEnemiesInWave(WaveConfigs[wave]));
        }
    }

    // Update is called once per frame
    private IEnumerator SpawnAllEnemiesInWave(CreateConfig waveConfig){

        for(int enemyCount=0; enemyCount < waveConfig.getNumberofEnemies(); enemyCount++){
            var enemy = Instantiate(
                        waveConfig.getEnemyPrefab(),
                        waveConfig.getWaypoints()[startingWave].transform.position,
                        Quaternion.identity
                    );
            enemy.GetComponent<EnemyPath>().setWaveConfigForEnemey(waveConfig);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpans());
        }
    }
}
