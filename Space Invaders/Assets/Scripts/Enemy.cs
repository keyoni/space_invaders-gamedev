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
        //nemyAnimator = GetComponent<Animator>();
        _enemyType = name;
        _currentEnemy = GetComponent<GameObject>();
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

    
}
