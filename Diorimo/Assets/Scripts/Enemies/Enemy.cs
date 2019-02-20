using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 5;
    public GameObject player;
    public PlayerController pc;
    public GameObject splat;
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
            Instantiate(splat, transform);
            --enemyHP;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Missile"))
        {
            Instantiate(splat, transform);
            enemyHP-= 2;
            Destroy(other.gameObject);
        }
    }    
}
