using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor3 : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Assassin"))
        {
            MenuCanvas.SetActive(true);
            Level.level4lock = true;
            Time.timeScale = 0;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
