using System;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBullet : MonoBehaviour
{
    public float speed = 5;
    public static event Action<String> EnemyDeath;

    public static event Action<GameObject> EnemyDeathAnimate;

    private MeshRenderer _mesh;

    private BoxCollider2D _collider2D;
    //public static event Action<GameObject> BarrierHit;
    //-----------------------------------------------------------------------------
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
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
  
        //Debug.Log($"Ouch! Said {hit} ");
        if(!collision.collider.CompareTag("Barrier"))
        {

            if (hit != "Player")
            {
                _mesh.enabled = false;
                _collider2D.enabled = false;
                
                //Effects Score and Enemy Speed
                EnemyDeathAnimate?.Invoke(collision.gameObject);
                EnemyDeath?.Invoke(collision.collider.name);
            }
            //Destroys Enemy and self
            Destroy(collision.gameObject,1f);
            Destroy(gameObject,5f);
          
        }


    }
}
