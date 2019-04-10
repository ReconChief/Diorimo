using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject pogoTutorial;

    private PlayerController pc;
    private PogoTrigger pogoTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        pogoTrigger = this.GetComponent<PogoTrigger>();
        pogoTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pogoTrigger.enabled = true;
            pogoTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        pogoTutorial.SetActive(false);
        pogoTrigger.enabled = false;
    }
}
