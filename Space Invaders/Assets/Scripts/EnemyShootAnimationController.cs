using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyBlock.EnemyShoot += EnemyShootAnimate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyShootAnimate(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().ShootAnimate();
    }
}
