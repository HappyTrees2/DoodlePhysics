using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Panel;
    public static bool GameIsPaused = false;

    public void OpenPanel()
    {
        if (Panel != null)
        {          

            Panel.SetActive(true);

            Time.timeScale = 0f;

            GameIsPaused = true;
        }
    }

    public void ResumeGame()
    {
       
        Panel.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {        
        Application.Quit();
    }

}
