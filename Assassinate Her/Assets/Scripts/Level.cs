using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
   
    
    [SerializeField] GameObject EntryScreen;
    [SerializeField] GameObject MainMenuScreen;
    [SerializeField] GameObject LockScreen;

    public static bool level2lock;
    public static bool level3lock;
    public static bool level4lock;
    public static bool level5lock;
    public static bool level6lock;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void EntryButton()
    {
        EntryScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
    }


    public void LoadLevel1()
    {
        
        SceneManager.LoadScene("Level1");

    }   
    public void LoadLevel2()
    {
        if(level2lock)
        SceneManager.LoadScene("Level2");
        else
        LockScreen.SetActive(true);

    }
    public void LoadLevel3()
    {
        if (level3lock)
            SceneManager.LoadScene("Level3");
        else
            LockScreen.SetActive(true);

    }

    public void LoadLevel4()
    {
        if (level4lock)
            SceneManager.LoadScene("Level4");
        else
            LockScreen.SetActive(true);

    }
    public void lockScreen()
    {
        LockScreen.SetActive(false);
    }
    
}
