using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{ 
    private Vector3 destinationPos;
    public float smoothness;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        
        if(player != null)
        {
            destinationPos = player.transform.position;
        }
        else
        {
            Debug.Log("Player not found");
        }
    }
    public void Update()
    {
        destinationPos = player.transform.position;
        transform.LookAt(destinationPos);
        transform.position = Vector3.Lerp(transform.position, destinationPos, smoothness * Time.deltaTime);
    }
}
