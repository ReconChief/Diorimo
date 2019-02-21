using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int randomizer = 0;
    public int enemyHP = 5;

    public GameObject[] regenerateHPItems = new GameObject [2];
    public GameObject regenerateMissileItem;

    public GameObject player;
    private PlayerController pc;
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
            if (pc.hp <= pc.maxCapHp)
            {
                randomizer = Random.Range(0, 14);

                if (randomizer == 0 || randomizer == 1 || randomizer == 2)
                {
                    //Small Health Packs
                    GameObject healthpack = (GameObject)Instantiate(regenerateHPItems[0], this.transform.position, this.transform.rotation);
                }

                else if (randomizer == 6 || randomizer == 7)
                {
                    //Medium Health Packs
                    GameObject healthpack = (GameObject)Instantiate(regenerateHPItems[1], this.transform.position, this.transform.rotation);
                }

                else if (randomizer == 11)
                {
                    //Large Health Packs
                    GameObject healthpack = (GameObject)Instantiate(regenerateHPItems[2], this.transform.position, this.transform.rotation);\
                }
            }

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
