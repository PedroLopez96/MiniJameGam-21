using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxMeleeScript : MonoBehaviour
{
    public GameObject HUD;
    private void OnEnable()
    {
        StartCoroutine(destroyMe());
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().animDeath();
            GameManager.scorePoints += 10;
            gameObject.SetActive(false);
            HUD.GetComponent<HUDScript>().updateHUD();   
        }
    }

    public IEnumerator destroyMe()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        gameObject.SetActive(false );
    }
}
