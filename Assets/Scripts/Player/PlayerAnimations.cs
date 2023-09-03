using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void animWalking()
    {
        animator.SetBool("Walk", true);
    }

    public void resetWalking()
    {
        animator.SetBool("Walk", false);
    }

    public void animAttackingStay()
    {
        animator.SetTrigger("AttackStanding");
    }

    public void animAttackingWalking() 
    {
        animator.SetTrigger("AttackWalking");
    }

}
