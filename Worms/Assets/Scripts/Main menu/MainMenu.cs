using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void Load2Player()
    {
        SceneManager.LoadScene("2Players");
    }

    public void Load4Player()
    {
        SceneManager.LoadScene("4Players");
    }

    public void ShowHowToPlay()
    {

    }

    public void BackToMainMenu()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
