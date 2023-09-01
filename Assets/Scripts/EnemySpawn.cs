using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int spawnInterval;
    public int totalEnemiesToSpawn;
    public GameObject enemyPrefab;
    private void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    public IEnumerator spawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-25, 25), 1, Random.Range(-25, 25)), Quaternion.identity);
        }
    }
}
