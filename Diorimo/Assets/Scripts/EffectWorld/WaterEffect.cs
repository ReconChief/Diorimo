using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
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
        if (!pc.gravitySuit)
        {
            pc.playerSpeed = 2.5f;
        }

        else
        {
            pc.playerSpeed = 4.5f;
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

        pc.playerSpeed = 4.5f;
    }
}