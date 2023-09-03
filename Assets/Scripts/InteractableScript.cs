using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public string item;
    private GameObject player;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
    }

    public void Interact()
    {
        // IF IS A WEAPON, EQUIP THE WEAPON
        if (transform.tag == "Interactable")
        {
            player.GetComponent<PlayerAttack>().equipWeapon(transform.name);
            Debug.Log("Equipped weapon");
        }
        // IF ITS THE LOOPING DEVICE, DEACTIVATE IT AND OPEN NEXT LEVEL GATE
        else if (transform.name == "LoopingDevice")
        {
            gameManager.GetComponent<LoopScript>().foundLoopDevice();
            Debug.Log("Found device!");
        }
        /* IF ITS A CHEST, STORE YOUR WEAPON IN THE CHEST
        else if (transform.tag == "Chest")
        {

        }*/

        Destroy(gameObject);


    }

}
