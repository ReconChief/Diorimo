using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    public GameObject boom;
    public GameObject pieces;
    private Transform trans;
    private int timer = 110;
    private bool hit=false;
    void Update()
    {
        trans = transform;
        if (hit) {
            timer--;
        }
        if (timer <= 0) {
            //this.gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            hit = true;
            Instantiate(boom, trans);
            Instantiate(pieces, trans);
            transform.localScale = transform.localScale*0.0025f;
            //this.gameObject.SetActive(false);
        }
    }
}
