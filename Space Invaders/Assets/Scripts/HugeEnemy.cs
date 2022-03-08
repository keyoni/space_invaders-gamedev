using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HugeEnemy : MonoBehaviour
{

    public float speedIncrease = 0.2f;
    public float speed = 5f;

    private bool _isVisible;

    private int _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerBullet.EnemyDeath += SpeedUp;
    }

    private void OnDestroy()
    {
        PlayerBullet.EnemyDeath -= SpeedUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isVisible)
        {
            Vector3 movement = new Vector3(speed * _direction,  0,0);

            movement *= Time.deltaTime;

            transform.Translate(movement);
        }

    }

    public void SetIsVisible(bool visible)
    {
        _isVisible = visible;
    }
    public void SetDirection(int direction)
    {
        _direction = direction;
    }
    

    private void SpeedUp(String type)
    {
        speed += speedIncrease;
    }

   
}
