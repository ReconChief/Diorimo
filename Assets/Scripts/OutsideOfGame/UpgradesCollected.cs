using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesCollected : MonoBehaviour
{

    public Text MorphBall;
    public Text FireElement;
    public Text WaterElement;
    public Text Electric;
    public Text MissilePickUp;
    public Text GravitySuit;
    public Text TempSuit;

    private GameObject player;
    private PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        MorphBall.text = "Morphball Collected: " + pc.morphBall + "\r\n";
        FireElement.text = "Fire Element Collected: " + pc.fireBeam + "\r\n";
        WaterElement.text = "Water Element Collected: " + pc.iceBeam + "\r\n";
        Electric.text = "Electric Element Collected: " + pc.electricBeam + "\r\n";
        MissilePickUp.text = "Missile Picked Up Collected: " + pc.missilePickedUp + "\r\n";
        GravitySuit.text = "Gravity Suit Collected: " + pc.gravitySuit + "\r\n";
        TempSuit.text = "Temperature Suit Collected: " + pc.tempSuit + "\r\n";
    }
}
