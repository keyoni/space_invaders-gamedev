using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;

    public static event Action<GameObject> PlayerKill;

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
        String hit = collision.collider.name;

        // todo - move trigger death animation on enemy death action
        //enemyAnimator.SetTrigger(Death);

        Debug.Log($"Ouch! Said {hit} ");
        if (!collision.collider.CompareTag("Barrier"))
        {

            if (hit == "Player")
            {
                // todo - player death action
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

}
