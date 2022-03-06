using System;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public static event Action<String> EnemyDeath;

    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        //Debug.Log("Wwweeeeee");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // todo - trigger death animation on enemy death action
        //enemyAnimator.SetTrigger(Death);
  
        Debug.Log($"Ouch! Said {collision.collider.tag} ");
                                                                
        EnemyDeath?.Invoke(collision.collider.tag);
        Destroy(collision.gameObject); 
        Destroy(gameObject);
    }
}
