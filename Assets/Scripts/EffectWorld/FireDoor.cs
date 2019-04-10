﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDoor : MonoBehaviour
{
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ElectricBeam"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
