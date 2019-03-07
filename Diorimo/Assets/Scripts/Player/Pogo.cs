using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pogo : MonoBehaviour
{
    private Animator anim;
    public PlayerController pc;
    public GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
            anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", speed);
        if (pc.walking)
            speed = 1;
        else
            speed = 0f;
        if (pc.pressed)
        {
            anim.SetBool("buttonDown", true);
        }
        else {
            anim.SetBool("buttonDown", false);
        }

        if (pc.released)
        {
            anim.SetBool("release", true);
        }
        else {
            anim.SetBool("release", false);
        }
    }
}
