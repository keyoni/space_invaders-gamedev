using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerBullet.EnemyDeathAnimate += DeathAnimateSend;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeathAnimateSend(GameObject enemy)
    {
        
        enemy.GetComponent<Enemy>().DeathAnimate("hi");
    }
}
