using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    //control the main menu

    //if the player clicks start
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
