using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWater : MonoBehaviour
{
    public GameObject WaterArea;

    void Start()
    {
        WaterArea.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WaterArea.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        WaterArea.SetActive(false);
    }
}
