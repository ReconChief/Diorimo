using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeamTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject FireBeamTutorial;

    private PlayerController pc;
    private FireBeamTrigger fireBeamTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        fireBeamTrigger = this.GetComponent<FireBeamTrigger>();
        fireBeamTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fireBeamTrigger.enabled = true;
            FireBeamTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FireBeamTutorial.SetActive(false);
        fireBeamTrigger.enabled = false;
    }
}
