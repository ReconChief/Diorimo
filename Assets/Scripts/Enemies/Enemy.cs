﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int randomizer = 0;
    public int enemyHP = 5;
    public bool isPlant;

    public GameObject[] regenerateHPItems = new GameObject [3];
    public GameObject regenerateMissileItem;
    public Vector3 fixPosition = new Vector3(0, 0.4f, 0);

    public GameObject player;
    public PlayerController pc;
    public GameObject splat;

    //Sound Effects
    public AudioSource enemyAttack;
    public AudioSource enemyHurt;
    public AudioSource enemyDeath;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            enemyDeath.Play();

            //Regenerate if HP and Missiles are lower than max
            if (pc.hp < pc.maxCapHp && pc.missiles < pc.maxMissiles)
            {
                randomizer = Random.Range(0, 10);

                if (randomizer == 0 || randomizer == 1 || randomizer == 2)
                {
                    //Small Health Pack
                    GameObject healthPack = (GameObject)Instantiate(regenerateHPItems[0],this.transform.position + fixPosition, this.transform.rotation);
                }

                else if (randomizer == 6 || randomizer == 7)
                {
                    //Medium Health Pack
                    GameObject healthPack = (GameObject)Instantiate(regenerateHPItems[1], this.transform.position + fixPosition, this.transform.rotation);
                }

                else if (randomizer == 8)
                {
                    //Large Health Pack
                    GameObject healthPack = (GameObject)Instantiate(regenerateHPItems[2], this.transform.position + fixPosition, this.transform.rotation);
                }

                else if (randomizer == 9)
                {
                    //Missile Pack
                    GameObject missilePack = (GameObject)Instantiate(regenerateMissileItem, this.transform.position + fixPosition, this.transform.rotation);
                }
            }

            //Regenerate if HP is lower than max
            if (pc.hp < pc.maxCapHp)
            {
                randomizer = Random.Range(0, 7);

                if (randomizer == 0 || randomizer == 1 || randomizer == 2)
                {
                    //Small Health Pack
                    GameObject healthPack = (GameObject)Instantiate(regenerateHPItems[0], this.transform.position + fixPosition, this.transform.rotation);
                }

                else if (randomizer == 3 || randomizer == 4)
                {
                    //Medium Health Pack
                    GameObject healthPack = (GameObject)Instantiate(regenerateHPItems[1], this.transform.position + fixPosition, this.transform.rotation);
                }

                else if (randomizer == 5)
                {
                    //Large Health Pack
                    GameObject healthPack = (GameObject)Instantiate(regenerateHPItems[2], this.transform.position + fixPosition, this.transform.rotation);
                }
            }

            //Regenerate if Missles is lower than max
            if (pc.missiles < pc.maxMissiles)
            {
                randomizer = Random.Range(0, 2);
                
                if (randomizer == 1)
                {
                    //Missile Pack
                    GameObject missilePack = (GameObject)Instantiate(regenerateMissileItem, this.transform.position + fixPosition, this.transform.rotation);
                }
            }

            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAttack.Play();

            if ( pc.transformed && pc.transformation == 1)
            {
                pc.hp -= 5;
                enemyHP -= 4;
            }

            else if (pc.hardened != null && pc.hardened)
            {
                pc.hp -= 0;
            }

            else if (pc.tempSuit != null && pc.tempSuit)
            {
                if (pc.gravitySuit != null && pc.gravitySuit)
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
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("ElectricBeam") || other.gameObject.CompareTag("WaterBeam") || other.gameObject.CompareTag("FireBeam"))
        {
            Instantiate(splat, transform);
            --enemyHP;
            Destroy(other.gameObject);
            enemyHurt.Play();
        }

        if (isPlant && other.gameObject.CompareTag("FireBeam"))
        {
            enemyHP = 0;
            enemyHurt.Play();
        }

        if (other.gameObject.CompareTag("Missile"))
        {
            Instantiate(splat, transform);
            enemyHP-= 10;
            Destroy(other.gameObject);
            enemyHurt.Play();
        }
    }    
}
