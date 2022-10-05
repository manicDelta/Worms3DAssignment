using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _helpMenu;

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
        _mainMenu.SetActive(false);
        _helpMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        _mainMenu.SetActive(true);
        _helpMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
