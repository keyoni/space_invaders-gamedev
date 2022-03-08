using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public static event Action BoundHit;

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Enemy"))
        {
            BoundHit?.Invoke();
        }

    }
}
