using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GC : MonoBehaviour
{
    public GameObject FirstButtonForPlayAgain;
    private EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgain() {
        SceneManager.LoadScene("Menu");
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButtonForPlayAgain, null);
    }
}
