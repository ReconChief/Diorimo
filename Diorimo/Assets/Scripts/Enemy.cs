using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyHP = 5;
    private GameObject player;
    private PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pc.tempSuit)
            {
                if (pc.gravtiySuit)
                {
                    pc.hp -= 4;
                }

                pc.hp -= 8;
            }

            else
            {
                pc.hp -= 12;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            --enemyHP;
            Destroy(other.gameObject);
        }
    }
}
