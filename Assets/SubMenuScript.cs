using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuScript : MonoBehaviour
{

    public void BackToMenu()
    {
        Debug.Log("Going back to main");
        SceneManager.LoadScene("MainMenu");
    }
    private void StartGame()
    {
        Debug.Log("Starting game now");
        SceneManager.LoadScene("Level1");
    }

    private void ShowCredits()
    {
        Debug.Log("Showing credits now");
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
