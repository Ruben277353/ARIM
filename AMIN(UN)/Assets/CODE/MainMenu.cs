using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public void  Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void conttinuegame()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("My Scenes");

    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
        
    }
    public void ExitInMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
    