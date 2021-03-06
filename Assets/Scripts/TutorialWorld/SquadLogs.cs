﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadLogs : MonoBehaviour
{
    private GameObject player;
    public GameObject log;
    private bool retrieved;
    private PlayerController pc;
    private SquadLogs Trigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        Trigger = this.GetComponent<SquadLogs>();
        Trigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger.enabled = true;
            log.SetActive(true);
            

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { 
        if (!retrieved)
        {
            pc.solidersFound++;
            retrieved = true;

        }
        log.SetActive(false);
        Trigger.enabled = false; }
    }
}
