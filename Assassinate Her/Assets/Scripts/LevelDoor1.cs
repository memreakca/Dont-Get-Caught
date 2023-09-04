using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor1 : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;

    
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.CompareTag("Assassin"))
        {
            Time.timeScale = 0;
            MenuCanvas.SetActive(true);

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                Level.level2lock = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                Level.level3lock = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                Level.level4lock = true;
            }
            else return;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
