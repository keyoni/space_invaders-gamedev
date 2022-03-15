using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public String gameScene;

    public String creditsScene;
    

    public static event Action MenuScreenClose;

    public Animator player;

    public Animator small;

    public Animator mid;

    public Animator large;

    public Animator huge;
    // Start is called before the first frame update
    void Start()
    {
        //MenuScreen?.Invoke();
        
        player.SetTrigger("Idle");
        mid.SetTrigger("Idle");
        small.SetTrigger("Idle");
        large.SetTrigger("Idle");
        huge.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMainGame()
    {
        SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
    }
    
    public void OpenCredits()
    {
        SceneManager.LoadScene(creditsScene, LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        MenuScreenClose?.Invoke();
    }
}
