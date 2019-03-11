using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controls;
    public GameObject credits;

    public void ChangeToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeToSoundTrack()
    {
        SceneManager.LoadScene("SoundTracks");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
        credits.SetActive(false);
    }
}
