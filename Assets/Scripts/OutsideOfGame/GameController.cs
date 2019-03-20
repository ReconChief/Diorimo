using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Canvas
    public GameObject controlScreen;
    public GameObject pauseScreen;
    public GameObject areYouSureScreen;
    public GameObject playerUIScreen;

    private GameObject respawnPoint;
    private GameObject player;
    private PlayerController pc;

    //EventSystem
    public EventSystem eventSystem;

    //Buttons for next scene
    public GameObject FirstButtonForMenu;
    public GameObject FirstButtonForControls;
    public GameObject FirstButtonForAreYouSure;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

        eventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();

        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.hp <= 0)
        {
            RespawnPlayer();
            pc.hp = pc.maxCapHp;
            pc.missiles = pc.maxMissiles;
        }
    }

    public void RespawnPlayer()
    {
        player.gameObject.transform.position = respawnPoint.transform.position;
    }

    public void ReturnToGame()
    {
        pauseScreen.SetActive(false);
        playerUIScreen.SetActive(true);
        pc.paused = false;
    }

    public void ReturnToPauseScreen()
    {
        pauseScreen.SetActive(true);
        controlScreen.SetActive(false);
        eventSystem.SetSelectedGameObject(FirstButtonForMenu, null);
    }

    public void GoToControlScreen()
    {
        pauseScreen.SetActive(false);
        controlScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(FirstButtonForControls, null);
    }

    public void AreYouSure()
    {
        pc.quit = true;
        pauseScreen.SetActive(false);
        areYouSureScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(FirstButtonForAreYouSure, null);
    }

    public void Yes()
    {
        SceneManager.LoadScene("Menu");
    }

    public void No()
    {
        pc.quit = false;
        pauseScreen.SetActive(true);
        areYouSureScreen.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButtonForMenu, null);
    }
}