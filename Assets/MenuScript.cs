using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using System.ComponentModel;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


//Author: Taneli Niskanen (no comments for this script, pretty self-explanatory.
public class MenuScript : MonoBehaviour
{
    Button buttonStartGame;
    Button buttonCredits;
    Button buttonExit;
    Slider VolumeMaster;

    // Start is called before the first frame update
    public void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        buttonStartGame = root.Q<Button>("StartGame");
        buttonExit = root.Q<Button>("QuitGame");
        buttonCredits = root.Q<Button>("Credits");
        VolumeMaster = root.Q<Slider>("MasterAudioSlider");


        buttonStartGame.clicked += StartGame;
        buttonCredits.clicked += ShowCredits;
        buttonExit.clicked += ExitGame;
        
    }

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
