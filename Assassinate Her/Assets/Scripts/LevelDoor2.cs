using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor2 : MonoBehaviour
{

    [SerializeField] GameObject MenuCanvas;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Assassin"))
        {
            MenuCanvas.SetActive(true);
            Level.level3lock = true;

        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
