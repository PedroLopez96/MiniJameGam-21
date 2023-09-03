using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void animDeath()
    {
        animator.SetBool("isDead", true);
        StartCoroutine(destroyMe());
    }

    public IEnumerator destroyMe()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colidiu");
        if (other.transform.tag == "Weapon")
        {
            Destroy(gameObject);
            Debug.Log("colidiu inimigo");
        }
            
    }
}
