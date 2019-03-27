﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBuilding : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pc.transformation = 0;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        pc.transformation = 1;
    }
}