using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RechargeStation : MonoBehaviour
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
            pc.hp = pc.maxCapHp;
            pc.missiles = pc.maxMissiles;

            if (pc.morphBall && pc.fireBeam && pc.iceBeam && pc.electricBeam && pc.tempSuit && pc.gravitySuit && pc.missilePickedUp)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
