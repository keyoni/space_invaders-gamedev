using System;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public static event Action<String> EnemyDeath;
    public static event Action<GameObject> BarrierHit;
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
        String hit = collision.collider.name;
        
        // todo - move trigger death animation on enemy death action
        //enemyAnimator.SetTrigger(Death);
  
        Debug.Log($"Ouch! Said {hit} ");
        if(!collision.collider.CompareTag("Barrier"))
        {

            if (hit != "Player")
            {
                EnemyDeath?.Invoke(collision.collider.name);
            }
            else if (hit == "Player")
            {
                // todo - player death action
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }


    }
}
