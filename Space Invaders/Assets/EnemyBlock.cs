using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    public float timerMax = 2f;
    private float _timer;

    private float _xMove = 0.5f;

    private float _yMove = 0;

    public GameObject enemySmallPrefab;
    public GameObject enemyMidPrefab;
    public GameObject enemyLargePrefab;
    public GameObject enemyHugePrefab;

    public GameObject rowPlaceHolder;
    public GameObject parentEnemy;

    public int numberOfColumns = 10;
    private bool down = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
        Boundary.BoundHit += DirectionSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        BlockMove();
        if (down)
        {
            _yMove = 0;
            down = false;
        }
    }

    private void BlockMove()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            if (_yMove < 0)
                down = true;
            
            transform.Translate(new Vector3(_xMove, _yMove, 0));
            _timer = timerMax;
        }
    }

    public void EnemySpawn()
    {
        for (int i = 0; i < 4; i++)
        {
            EnemySpawnRow(i);
        }
    }

    public void EnemySpawnRow(int type)
    {
        switch (type)
        {
            case 0:
            for (int i = 0; i < numberOfColumns; i++)
            {
                Vector3 space = new Vector3(i + (i+1), 0,0);
                GameObject enemy = Instantiate(enemyLargePrefab, rowPlaceHolder.transform.position + space,
                    Quaternion.identity);
                enemy.transform.SetParent(transform);
            }
            break;
            case 1:
                for (int i = 0; i < numberOfColumns; i++)
                {
                    Vector3 space = new Vector3(i + (i+1), -2,0);
                    GameObject enemy = Instantiate(enemyMidPrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }
                break;
            case 2:
                for (int i = 0; i < numberOfColumns; i++)
                {
                    Vector3 space = new Vector3(i + (i+1), -4,0);
                    GameObject enemy = Instantiate(enemySmallPrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }
                break;
            case 3:
                for (int i = 0; i < numberOfColumns; i++)
                {
                    Vector3 space = new Vector3(i + (i+1), -6,0);
                    GameObject enemy = Instantiate(enemySmallPrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }
                break;
        
        }

       
    } 
    private void DirectionSwitch()
    {
        _xMove = -_xMove;
        _yMove = -0.5f;
    }
}
