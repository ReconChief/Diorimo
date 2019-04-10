﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedHpRegen : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pc.hp < pc.maxCapHp)
            {
                pc.hp += 18;

                if (pc.hp > pc.maxCapHp)
                {
                    pc.hp = pc.maxCapHp;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
