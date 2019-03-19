using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject controlScreen;
    public GameObject pauseScreen;
    public GameObject areYouSureScreen;
    public GameObject playerUIScreen;

    private GameObject respawnPoint;
    private GameObject player;
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

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
    }

    public void GoToControlScreen()
    {
        pauseScreen.SetActive(false);
        controlScreen.SetActive(true);
    }

    public void AreYouSure()
    {
        pc.quit = true;
        pauseScreen.SetActive(false);
        areYouSureScreen.SetActive(true); 
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
    }
}