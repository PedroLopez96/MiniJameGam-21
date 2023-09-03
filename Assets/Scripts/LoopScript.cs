using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{

    public int loopDuration = 5;
    public int timeElapsed;
    public bool foundDevice = false;
    public GameObject loopDevice;
    public GameObject player;
    public GameObject[] enemies;

    private void Start()
    {
        timeElapsed = 0;
        StartCoroutine(loopCountdown());
    }

    //TODO: LOOP LASTS 60 SECONDS, IF 60 SECONDS PASS:
    //      PLAYER GOES BACK TO BEGGINING OF LEVEL
    //             LOSE ITS WEAPON
    //             ALL ENEMIES ARE DESTROYED AND ENEMYSPAWNED IS RESTARTED
    //             LOOPING DEVICE IS RESPAWNED

    // INSTANTIATE THE LOOP DEVICE IN A DIFFERENT POSITION EVERY TIME THE LOOP RESTARTS
    //

    public IEnumerator loopCountdown()
    {
        while ((timeElapsed <= loopDuration) && foundDevice == false)
        {
            yield return new WaitForSeconds(1);
            timeElapsed++;
            GetComponent<HUDScript>().updateHUD();

            if (foundDevice == true)
            {
                GetComponent<HUDScript>().updateHUD();
            }

            if (timeElapsed >= loopDuration && foundDevice == false)
                loopBack();
        }
    }

    public void loopBack()
    {
        Debug.Log("Loopback! ");
        // DESTROY ALL ENEMIES
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }

        // BRING BACK PLAYER TO INITIAL POSITION
        player.GetComponent<PlayerController>().playerLoopback();

        // TIME ELAPSED BACK TO 0
        timeElapsed = 0;
        
    }

    public void instantiateLoopDevice()
    {
        Instantiate(loopDevice);
    }

    public void foundLoopDevice()
    {
        foundDevice = true;
        
        GetComponent<HUDScript>().updateHUD();

    }
}
