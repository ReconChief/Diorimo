using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;
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
}
