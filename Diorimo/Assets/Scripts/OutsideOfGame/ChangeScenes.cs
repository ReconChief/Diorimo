using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{    
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeToSoundTrack()
    {
        SceneManager.LoadScene("SoundTrack");
    }
}
