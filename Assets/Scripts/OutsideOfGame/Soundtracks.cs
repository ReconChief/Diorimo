using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtracks : MonoBehaviour
{
    public AudioSource mainMenu;
    public AudioSource forestArea;
    public AudioSource lavaArea;
    public AudioSource waterArea;

    public void playMainMenu()
    {
        mainMenu.Play();
        forestArea.Stop();
        lavaArea.Stop();
        waterArea.Stop();
    }

    public void playForestArea()
    {
        mainMenu.Stop();
        forestArea.Play();
        lavaArea.Stop();
        waterArea.Stop();
    }

    public void playLavaArea()
    {
        mainMenu.Stop();
        forestArea.Stop();
        lavaArea.Play();
        waterArea.Stop();
    }

    public void playWaterArea()
    {
        mainMenu.Stop();
        forestArea.Stop();
        lavaArea.Stop();
        waterArea.Play();
    }
}
