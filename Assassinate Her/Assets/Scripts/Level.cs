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
    public bool level4lock;
    public bool level5lock;
    public bool level6lock;
    public bool level7lock;
    public bool level8lock;
    public bool level9lock;
    public bool level10lock;

    
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

    public void lockScreen()
    {
        LockScreen.SetActive(false);
    }
    
}
