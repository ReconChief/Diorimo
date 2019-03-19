using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeHPRegen : MonoBehaviour
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
                pc.hp += 30;

                if (pc.hp > pc.maxCapHp)
                {
                    pc.hp = pc.maxCapHp;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
