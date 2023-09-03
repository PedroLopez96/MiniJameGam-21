using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float minX, maxX;
    public float minZ, maxZ;
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
            Instantiate(enemyPrefab, new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ,maxZ)), Quaternion.identity);
            spawnedEnemies++;
            
        }
    }

    public void resetSpawn()
    {
        spawnedEnemies = 0;
    }
}
