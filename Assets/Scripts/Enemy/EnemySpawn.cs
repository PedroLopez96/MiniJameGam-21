using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnInterval;
    public int totalEnemiesToSpawn;
    public int spawnedEnemies;
    public GameObject enemyPrefab;
    private void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    public IEnumerator spawnEnemies()
    {
        while (spawnedEnemies <= totalEnemiesToSpawn)
        {
            
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-25, 25), 1, Random.Range(-25, 25)), Quaternion.identity);
            spawnedEnemies++;
            
        }
    }
}
