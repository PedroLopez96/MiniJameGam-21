using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public AudioClip hit;
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
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidiu");
        if (other.transform.tag == "Weapon")
        {
            AudioScript.play(hit);
            animator.SetBool("isDead", true);
            Destroy(gameObject, 0.4f);
            Debug.Log("colidiu inimigo");
            GetComponent<EnemyScript>().enabled = false;
        }
            
    }
    
}
