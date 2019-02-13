using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBullet : MonoBehaviour
{
    public GameObject player;
    public PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pc.tempSuit)
            {
                if (pc.gravtiySuit)
                {
                    pc.hp -= 5;
                }

                pc.hp -= 10;
            }

            else
            {
                pc.hp -= 13;
            }
        }

        Destroy(this.gameObject);
    }
}