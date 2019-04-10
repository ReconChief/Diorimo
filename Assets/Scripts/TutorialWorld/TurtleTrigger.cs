using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject turtleTutorial;

    private PlayerController pc;
    private TurtleTrigger turtleTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        turtleTrigger = this.GetComponent<TurtleTrigger>();
        turtleTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turtleTrigger.enabled = true;
            turtleTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        turtleTutorial.SetActive(false);
        turtleTrigger.enabled = false;
    }
}
