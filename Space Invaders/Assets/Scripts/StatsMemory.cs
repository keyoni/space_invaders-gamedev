using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsMemory : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScore;
    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            CreateHighScore();
        }

        if (PlayerPrefs.GetInt("TotalKills") == 0)
        {
            CreateTotalKills();
        }
        ScoreTracker.TotalKills += ScoreCheckAndKillUpdate;
        ScoreTracker.NewHighScore += UpdateHighScore;
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString("0000");
    }

    private void CreateTotalKills()
    {
        PlayerPrefs.SetInt("TotalKills", 1);
    }

    private void CreateHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void ScoreCheckAndKillUpdate( int killCount)
    {
        PlayerPrefs.SetInt("TotalKills",PlayerPrefs.GetInt("TotalKills") + killCount);
    }

   private void UpdateHighScore(int highScoreNew)
   {
       PlayerPrefs.SetInt("HighScore", highScoreNew);
       Debug.Log("NewHighScore!!!");
       int hs = PlayerPrefs.GetInt("HighScore");
       highScore.text = hs.ToString("0000");
   }
}
