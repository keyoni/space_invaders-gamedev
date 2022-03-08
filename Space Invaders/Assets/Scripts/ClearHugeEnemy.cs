using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClearHugeEnemy : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}