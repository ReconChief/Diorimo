using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject missileDisplay;

    public Slider healthSlider;
    public Slider missileSlider;

    public Text healthBarCounterDisplay;
    public Text missileCounterDisplay;

    public GameObject player;
    public PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        missileDisplay.SetActive(false);
    }
    
    void Update()
    {
        healthSlider.maxValue = pc.maxCapHp;
        healthSlider.value = pc.hp;

        healthBarCounterDisplay.text = "HP: " + pc.hp.ToString() + "/" + pc.maxCapHp.ToString();

        if (pc.missilePickedUp && !pc.ballForm)
        {
            missileDisplay.SetActive(true);
            missileCounterDisplay.text = "Missiles: " + pc.missiles.ToString() + "/" + pc.maxMissiles.ToString();
            missileSlider.maxValue = pc.maxMissiles;
            missileSlider.value = pc.missiles;
        }

        else
        {
            missileDisplay.SetActive(false);
        }
    }
}
