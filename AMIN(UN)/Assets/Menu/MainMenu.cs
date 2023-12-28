using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("My Scenes");

    }
    public void ExitGame()
    {
        Debug.Log("���� ���������");
        Application.Quit();
        
    }
    public void ExitInMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
    