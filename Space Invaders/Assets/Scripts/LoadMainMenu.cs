using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    
    public String menuScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Help From :https://stackoverflow.com/questions/62553025/unity-load-scene-after-two-seconds
    IEnumerator OpenMenu()
    {
   
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
    }
}
