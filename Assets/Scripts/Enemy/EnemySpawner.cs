using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool isSpawning;
    public int spawnDelay;
    public GameObject enemyToSpawn;
    void Update()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        if (isSpawning == false)
        {
            isSpawning = true;
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(enemyToSpawn, transform);
            isSpawning = false;
        }
    }
}
