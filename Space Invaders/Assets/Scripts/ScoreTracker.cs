using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int _currentScore = 0;
    private int _currentKills = 0;

    public TextMeshProUGUI score;

    public static event Action KillCountHit;
    public static event Action<int> NewHighScore;
    public static event Action<int> TotalKills;
    // Start is called before the first frame update
    void Start()
    {
        PlayerBullet.EnemyDeath += AddScore;
        PlayerBullet.EnemyDeath += EnemyKillsUpdate;
        BottomBoundary.BottomBoundHit += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(String enemyType)
    {
        Debug.Log(enemyType);
        if (enemyType.Contains("Small")) 
        {
            _currentScore += 10;
        } 
        else if (enemyType.Contains("Mid"))
        {
            _currentScore += 20;
        }
        else if (enemyType.Contains("Large"))
        {
            _currentScore += 30;
        }
        else if (enemyType.Contains("Huge"))
        {
            int randomNum = UnityEngine.Random.Range(200, 400);
            randomNum -= randomNum % 10;
            _currentScore += randomNum;
        }

        if (_currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            NewHighScore?.Invoke(_currentScore);
        }
        score.text = _currentScore.ToString("0000");
    }
    
    // Keeps track of how many enemies killed, if divisible by a certain number, spawn huge 
    private void EnemyKillsUpdate(String enemyType)
    {
        _currentKills += 1;
        if (_currentKills % 7 == 0)
        {
            KillCountHit?.Invoke();
        }
    }

    private void GameOver()
    {
        TotalKills?.Invoke(_currentKills);
    }
}
