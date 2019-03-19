using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSprites : MPBullet
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pc.transform.position, 2.5f * Time.deltaTime);
    }
}
