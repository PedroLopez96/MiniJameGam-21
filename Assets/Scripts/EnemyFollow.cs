using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float maxDelta;
    private Vector3 destinationPos;

    private void Start()
    {
        
    }
    public void Update()
    {
        destinationPos = player.transform.position;
        transform.LookAt(destinationPos);
        transform.position = Vector3.MoveTowards(transform.position, destinationPos, maxDelta * Time.deltaTime);
    }
}
