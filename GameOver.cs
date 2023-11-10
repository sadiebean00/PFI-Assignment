//Property of Sadie Sundt. Bournemouth Univeristy. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //This bit of code is used to load the Main Menu screen when the return button is clicked
    public void MainMenuReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
