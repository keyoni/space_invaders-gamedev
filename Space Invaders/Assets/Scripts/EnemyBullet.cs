using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;

    //public static event Action<GameObject> PlayerKill;
    public static event Action BulletDestroyed;
    public static event Action PlayerDied;
    
    void OnEnable() {
        GameObject[] friendlyFire = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in friendlyFire) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }
        
    }
    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        String hit = collision.collider.tag;

        // todo - move trigger death animation on enemy death action
        //enemyAnimator.SetTrigger(Death);
        
        if (hit.Contains("Player"))
        {
            // todo - player death action
            collision.gameObject.GetComponent<Player>().DeathAnimate();
            PlayerDied?.Invoke();
            Destroy(collision.gameObject,1f);
            Destroy(gameObject);
       
        }
        else if (hit.Contains("Barrier"))
        {
            Destroy(gameObject);
          
        }
        else if (hit == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }

    }

    private void OnDestroy()
    {
        BulletDestroyed?.Invoke();
        
    }
}
