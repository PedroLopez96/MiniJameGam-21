using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLoopScript : MonoBehaviour
{
    public AudioClip tp;
    public float minX, maxX;
    public float minZ, maxZ;
    public float timeLeft;
    public float loopDuration;
    public GameObject player;
    public GameObject loopDevice;
    public GameObject[] allEnemies;
    public GameObject sword;
    public GameObject canvas;

    void Start()
    {
        // SPAWN SWORD RANDOM
        spawnSword();
        // SPAWN DEVICE RANDOM
        spawnDevice();

        timeLeft = loopDuration;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log("time left: " + timeLeft);
        } 
        else
        {
            Debug.Log("time is up");
            timeUp();
        }        
    }

    public void timeUp()
    {
        // CHECK IF PLAYER DEACTIVATED THE DEVICE
        if (player.GetComponent<PlayerScript>().deactivatedDevice == true)
        {
            // IF YES, OPEN DOOR TO LEVEL 2
            Debug.Log("Level 2 is unlocked");

        }
        else // IF NOT, LOOPBACK 
        {
            AudioScript.play(tp);
            timeLeft = loopDuration;
            player.GetComponent<PlayerScript>().getPlayerBackOrigin();
            killAllEnemies();
            spawnDevice();
            spawnSword();
            GetComponent<EnemySpawn>().resetSpawn();
        }

    }

    public void killAllEnemies()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < allEnemies.Length; i++)
            Destroy(allEnemies[i]);
        
    }

    public void spawnDevice()
    {
        // check if objects exists and if so, destroy
        if (GameObject.Find("LoopDevice"))
            Destroy(GameObject.Find("LoopDevice"));

        // NEW RANDOM POSITION
        Vector3 spawnPosition = new Vector3 (Random.Range(-30, 0), 1, Random.Range(0, 40));

        // INSTANTIATE IN NEW POSITION
        GameObject _object = Instantiate(loopDevice, spawnPosition, Quaternion.identity);
        _object.transform.name = "LoopDevice";

    }

    public void spawnSword()
    {
        // check if objects exists and if so, destroy
        if (GameObject.Find("Sword"))
            Destroy(GameObject.Find("Sword"));

        // NEW RANDOM POSITION
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));

        // INSTANTIATE IN NEW POSITION
        GameObject _object = Instantiate(sword, spawnPosition, new Quaternion(-180, 0, 0, 0));
        _object.transform.name = "Sword";
    }
}
