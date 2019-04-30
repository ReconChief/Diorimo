using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OutOfBounds : MonoBehaviour
{
    private GameController gc;
    private GameObject player;
    private PlayerController pc;
    public GameObject fire;
    private bool hit;
    //time shit
    private float slowdownFactor = 0.05f;
    private float slowdownLength = 2f;
    private int timer;
    //death shit
    public Image black;
    void Start()
    {
        timer = 300;
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (hit)
        {
            if (timer >= 0)
            {

                var colorVal = black.color;
                colorVal.a += 0.003f;
                black.color = colorVal;
                Time.timeScale = 0.05f;
                timer--;

            }

            if (timer <= 0)
            {
                pc.hp = pc.maxCapHp;
                pc.missiles = pc.maxMissiles;
                gc.RespawnPlayer();
               
                hit = false;
            }
        }
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(fire, pc.transform);
            timer = 300;
            hit = true;
        }
    }
}