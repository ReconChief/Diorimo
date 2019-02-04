using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    private int enemyHP = 5;
    private GameObject player;
    private PlayerController pc;
    private WaterEffect water;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        water = this.GetComponent<WaterEffect>();
        water.enabled = false;
    }

    void Update()
    {
        if (!pc.gravtiySuit)
        {
            pc.playerSpeed = 2;
        }

        else
        {
            pc.playerSpeed = 5;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            water.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        water.enabled = false;

        pc.playerSpeed = 5;
    }
}