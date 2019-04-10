using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLava : MonoBehaviour
{
    public GameObject LavaArea;

    void Start()
    {
        LavaArea.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LavaArea.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        LavaArea.SetActive(false);
    }
}
