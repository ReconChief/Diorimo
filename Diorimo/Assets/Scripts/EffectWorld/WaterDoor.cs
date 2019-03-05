using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDoor : MonoBehaviour
{
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterBeam"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
