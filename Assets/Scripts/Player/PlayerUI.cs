using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject missileDisplay;

    public Image healthBarLeft;
    public Image healthBarRight;
    public Image missileBar;

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
        healthBarLeft.fillAmount = pc.hp / pc.maxCapHp;
        healthBarRight.fillAmount = pc.hp / pc.maxCapHp;

        healthBarCounterDisplay.text = "HP: " + pc.hp.ToString() + "/" + pc.maxCapHp.ToString();

        if (pc.missilePickedUp && !pc.ballForm)
        {
            missileDisplay.SetActive(true);
            missileCounterDisplay.text = "Missiles: " + pc.missiles.ToString() + "/" + pc.maxMissiles.ToString();

            missileBar.fillAmount = pc.missiles / pc.maxMissiles;
        }

        else
        {
            missileDisplay.SetActive(false);
        }
    }
}
