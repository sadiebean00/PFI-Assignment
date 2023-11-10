//Property of Sadie Sundt. Bournemouth University. 2020.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialMenu;
    public GameObject settingsMenu;
    //This controls the play button and loads the first level.
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    //This loads the tutorial menu and hides the main menu. It also keeps the settings menu hidden.
    public void Tutorial()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    //This activates the settings menu and hides both the main menu and the tutorial menu
    public void Settings()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    //This happens when the back button is clicked and it shows the main menu and hides the other two menus
    public void Back()
    {
        mainMenu.SetActive(true);
        tutorialMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    //This quits the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
