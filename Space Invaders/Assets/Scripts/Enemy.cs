using System;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    private Animator enemyAnimator;
    private static readonly int Death = Animator.StringToHash("Death");

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        // todo - trigger death animation
        enemyAnimator.SetTrigger(Death);
        Destroy(collision.gameObject); // destroy bullet
        Debug.Log("Ouch!");
    }
}
