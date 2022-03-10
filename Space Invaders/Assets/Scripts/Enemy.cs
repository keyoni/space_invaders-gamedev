using System;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    private Animator _enemyAnimator;
    private static readonly int Death = Animator.StringToHash("Death");
    private String _enemyType;
    private GameObject _currentEnemy;
    
    //public static event Action<String> EnemyDeath;

    private void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _enemyType = name;
        _currentEnemy = GetComponent<GameObject>();
        //PlayerBullet.EnemyDeath += DeathAnimate;
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        // // todo - trigger death animation
        // //enemyAnimator.SetTrigger(Death);
        // Destroy(collision.gameObject); // destroy bullet
        // Debug.Log($"Ouch! Said {_enemyType} ");
        //                                                         
        // EnemyDeath?.Invoke(_enemyType);
        // Destroy(_currentEnemy);
    }

    public void DeathAnimate(String enemyType)
    {
        Debug.Log("I was hit!!!");
        _enemyAnimator.SetTrigger(Death);
    }

    
}
