using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BurningPlatform : MonoBehaviour
{
    public bool burning;
    public GameObject fire;
    private GameObject player;
    private PlayerController pc;
    private GameController gc;
    private bool hit;
    private int timer;
    public Image black;
    public Material charred;
    // Start is called before the first frame update
    void Start()
    {
        burning = true;
        
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
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
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (burning)
            {
                Instantiate(fire, pc.transform);
                timer = 300;
                hit = true;
            }
        }
        if (collision.gameObject.CompareTag("WaterBeam")) {
            if (burning) {
                gameObject.GetComponent<MeshRenderer>().material = charred;
                burning = false;
                
            }
        }
    }
}
