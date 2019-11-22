using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject Panel;
    public static bool GameIsPaused = false;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);

            Time.timeScale = 0f;

            GameIsPaused = true;
        }
    }
}
