using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject chargerTutorial;

    private PlayerController pc;
    private ChargerTrigger chargerTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        chargerTrigger = this.GetComponent<ChargerTrigger>();
        chargerTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chargerTrigger.enabled = true;
            chargerTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        chargerTutorial.SetActive(false);
        chargerTrigger.enabled = false;
    }
}
