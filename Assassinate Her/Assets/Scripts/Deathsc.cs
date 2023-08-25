using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathsc : MonoBehaviour
{
    public static Deathsc instance;
    public GameObject deathpanel;

    private void Awake()
    {
        instance = this;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void openDeathPanel()
    {
        deathpanel.SetActive(true);
    }
}
