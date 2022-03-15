using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    
    public String creditsScene;
    // Start is called before the first frame update
    void Start()
    {
        EnemyBullet.PlayerDied += OpenCreditsStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OpenCreditsStart()
    {
        StartCoroutine(OpenCredits());
    }

    // Help From :https://stackoverflow.com/questions/62553025/unity-load-scene-after-two-seconds
    IEnumerator OpenCredits()
    {
   
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(creditsScene, LoadSceneMode.Single);
    }
}
