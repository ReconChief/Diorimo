using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Canvas shit
    public GameObject controlScreen;
    public GameObject pauseScreen;
    public GameObject areYouSureScreen;
    public GameObject playerUIScreen;

    //Spawn Areas
    private GameObject respawnPoint;
    private GameObject volcanoRespawnPoint;
    private GameObject waterRespawnPoint;
    private GameObject forestRespawnPoint;

    //Active Areas
    public GameObject waterArea;
    public GameObject volcanoArea;
    public GameObject forestArea;

    private GameObject player;
    private PlayerController pc;

    //EventSystem
    private EventSystem eventSystem;

    //Buttons for next scene
    public GameObject FirstButtonForMenu;
    public GameObject FirstButtonForControls;
    public GameObject FirstButtonForAreYouSure;

    
    //time shit
    private float slowdownFactor = 0.05f;
    private float slowdownLength = 2f;
    private int timer;

    //death shit
    public Image black;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 300;
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        volcanoRespawnPoint = GameObject.FindGameObjectWithTag("VolcanoSpawn");
        waterRespawnPoint = GameObject.FindGameObjectWithTag("WaterSpawn");
        forestRespawnPoint = GameObject.FindGameObjectWithTag("ForestSpawn");

        eventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (pc.hp <= 0)
        {
            pc.isDead = true;
            pc.playerUI.SetActive(false);
            if (timer >= 0)
            {
                
                var colorVal = black.color;
                colorVal.a += 0.003f;
                black.color = colorVal;
                Time.timeScale = 0.05f;
                timer--;

            }

            if (timer <= 0)
            {
                pc.hp = pc.maxCapHp;
                pc.missiles = pc.maxMissiles;
                RespawnPlayer();
            }



        }
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void RespawnPlayer()
    {
        if (volcanoArea.activeSelf && pc.tempSuit)
        {
            var colorVal = black.color;
            colorVal.a = 0f;
            black.color = colorVal;
            Time.timeScale = 1;
            player.gameObject.transform.position = volcanoRespawnPoint.transform.position;
            timer = 300;
            pc.playerUI.SetActive(true);
        }

        else if (forestArea.activeSelf)
        {
            var colorVal = black.color;
            colorVal.a = 0f;
            black.color = colorVal;
            Time.timeScale = 1;
            player.gameObject.transform.position = forestRespawnPoint.transform.position;
            timer = 300;
            pc.playerUI.SetActive(true);
        }

        else if (waterArea.activeSelf)
        {
            var colorVal = black.color;
            colorVal.a = 0f;
            black.color = colorVal;
            Time.timeScale = 1;
            player.gameObject.transform.position = waterRespawnPoint.transform.position;
            timer = 300;
            pc.playerUI.SetActive(true);
        }

        else
        {
            var colorVal = black.color;
            colorVal.a = 0f;
            black.color = colorVal;
            Time.timeScale = 1;
            player.gameObject.transform.position = respawnPoint.transform.position;
            timer = 300;
            pc.playerUI.SetActive(true);
        }
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