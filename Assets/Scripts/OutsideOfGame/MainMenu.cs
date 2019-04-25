using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    //Canvas
    public GameObject mainMenu;
    public GameObject controls;
    public GameObject credits;
    public GameObject narrative;

    //Buttons for next scene
    public GameObject FirstButtonForMenu;
    public GameObject FirstButtonForControls;
    public GameObject FirstButtonForCredits;

    public void ChangeToGame()
    {
        narrative.SetActive(true);
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
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButtonForControls, null);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButtonForCredits, null);
    }

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
        credits.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButtonForMenu, null);
    }
}
