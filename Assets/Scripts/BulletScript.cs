using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 destinationPosition;
    public float bulletSpeed;
    public int bulletDamage;

    private void Update()
    {
        var step = bulletSpeed * Time.deltaTime;    
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, step);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("Hit enemy!");
            Destroy(transform.gameObject);
            collision.transform.GetComponent<EnemyScript>().takeDamage(bulletDamage);
        }

        StartCoroutine(Destroy());
        
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
