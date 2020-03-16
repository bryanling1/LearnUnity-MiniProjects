using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float minRandomSpawnTime = 1f;
    [SerializeField] float maxRandomSpawnTime = 3f;
    [SerializeField] Attacker attackerPrefab;

    bool spawn = true;

    void Start()
    {
        StartCoroutine(spawnAttacker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnAttacker(){
        while(spawn){
            yield return new WaitForSeconds(UnityEngine.Random.Range(minRandomSpawnTime, maxRandomSpawnTime));
            Instantiate(attackerPrefab, transform.position, transform.rotation);
        }
    }
}
