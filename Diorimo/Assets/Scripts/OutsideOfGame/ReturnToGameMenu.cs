using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToGameMenu : MonoBehaviour
{
    public void ChangeToGameMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
