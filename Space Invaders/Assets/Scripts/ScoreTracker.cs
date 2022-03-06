using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int _currentScore = 0;

    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        Bullet.EnemyDeath += AddScore;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(String enemyType)
    {
        switch (enemyType)
        {
            case "Small":
                _currentScore += 10;
                break;
            case "Mid":
                _currentScore += 20;
                break;
            case "Large":
                _currentScore += 30;
                break;
            case "Huge":
                int randomNum = UnityEngine.Random.Range(200, 400);
                randomNum -= randomNum % 10;
                _currentScore += randomNum;
                break;
                
        }
        score.text = _currentScore.ToString("0000");
    }
}
