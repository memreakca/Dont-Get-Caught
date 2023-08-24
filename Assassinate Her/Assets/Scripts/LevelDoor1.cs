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
            MenuCanvas.SetActive(true);
            Level.level2lock = true;

        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
