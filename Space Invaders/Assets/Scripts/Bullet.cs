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
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        String hit = collision.collider.tag;
        
        // todo - move trigger death animation on enemy death action
        //enemyAnimator.SetTrigger(Death);
  
        Debug.Log($"Ouch! Said {hit} ");
        if (hit != "Player")
        {
            EnemyDeath?.Invoke(collision.collider.tag);
        }
        else if(hit == "Player")
        {
            // todo - player death action
        }
        else
        {
            
            // todo - barrier hit
        }

        Destroy(collision.gameObject); 
        Destroy(gameObject);
    }
}
