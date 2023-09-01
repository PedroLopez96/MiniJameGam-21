using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public int damage;


    public void takeDamage(int hitDamage)
    {
        Debug.Log("Enemy took damage");
        health -= hitDamage;
        if (health < 0)
        {
            Destroy(gameObject);    
        }
    }
}
