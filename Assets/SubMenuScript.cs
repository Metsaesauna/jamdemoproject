using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: Taneli Niskanen (I had to make this script because Unity UI Builder is stupid)
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
        SceneManager.LoadScene("PlayTrans");
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
