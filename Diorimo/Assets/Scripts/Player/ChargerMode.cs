using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMode : MonoBehaviour
{
    private Animator anim;
    public PlayerController pc;
    public GameObject player;
    
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
        
        if (pc.walking)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false); 
        if (pc.charging)
        {
            anim.SetBool("Pressed", true);
        }
        else
        {
            anim.SetBool("Pressed", false);
        }
    }
}
