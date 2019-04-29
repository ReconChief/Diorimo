using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControls : MonoBehaviour
{
    public GameObject currentDisplay;
    public GameObject Display;
    public GameObject other;
    private int timer;
    private GameObject player;
    private PlayerController pc;
    [Header("UI")]
    public GameObject terminal;
    public GameObject enemies;
    public GameObject upgrades;
    public GameObject logs;
    public GameObject Loading;
    [Space]
    public GameObject electricBeamTutorial;
    public GameObject fireBeamTutorial;
    public GameObject waterBeamTutorial;
    public GameObject gravBootsTutorial;
    public GameObject tempSuitTutorial;
    public GameObject missileTutorial;
    [Space]
    public GameObject bugInfo;
    public GameObject mPInfo;
    public GameObject pyroInfo;
    public GameObject plumeInfo;
    public GameObject dolphinInfo;
    public GameObject fishInfo;
    [Space]
    [Header("Enemies")]
    public GameObject bug;
    public GameObject mP;
    public GameObject pyro;
    public GameObject plume;
    public GameObject dolphin;
    public GameObject fish;
    [Space]
    [Header("Upgrades")]
    public GameObject electric;
    public GameObject fire;
    public GameObject water;
    public GameObject gravBoots;
    public GameObject tempSuit;
    public GameObject missiles;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > -12) {

            timer--;
        }
        else if (timer <= 0)
        {
            Loading.SetActive(false);
        }
        
    }
    public void GoToAreasScreen()
    {
        terminal.SetActive(false);
        enemies.SetActive(true);
        
    }
    public void GoToUpgradesScreen()
    {
        terminal.SetActive(false);
        upgrades.SetActive(true);

    }
    public void GoToLogsScreen()
    {
        terminal.SetActive(false);
        logs.SetActive(true);

    }
    public void ExitTerminal() {
        timer = 150;
        terminal.SetActive(false);
        pc.consoleInUse=false;
        pc.transform.position = pc.ds.transform.position;
        if (timer > 0)
        {
            Loading.SetActive(true);
        }
        else if (timer <= 0)
        {
            Loading.SetActive(false);
        }
        
    }
    public void SelectElectric() {
        Clear();
        electric.SetActive(true);
       
        electricBeamTutorial.SetActive(true);
    }
    public void Selectfire()
    {
        Clear();
        fire.SetActive(true);
        fireBeamTutorial.SetActive(true);
    }
    public void SelectGravBoots()
    {
        Clear();
        gravBoots.SetActive(true);
        gravBootsTutorial.SetActive(true);
    }
    public void SelectWater()
    {
        Clear();
        water.SetActive(true);
        waterBeamTutorial.SetActive(true);
    }
    public void SelectMissiles()
    {
        Clear();
        missiles.SetActive(true);
        missileTutorial.SetActive(true);
    }
    public void SelectTempSuit()
    {
        Clear();
        tempSuit.SetActive(true);
        tempSuitTutorial.SetActive(true);
    }
    public void SelectBug()
    {
        Clear();
        bug.SetActive(true);
        bugInfo.SetActive(true);
    }
    public void SelectMP()
    {
        Clear();
        mP.SetActive(true);
        mPInfo.SetActive(true);
    }
    public void SelectPyro()
    {
        Clear();
        pyro.SetActive(true);
        pyroInfo.SetActive(true);
    }
    public void SelectLavaPlume()
    {
        Clear();
        plume.SetActive(true);
        plumeInfo.SetActive(true);
    }
    public void SelectDolphin()
    {
        Clear();
        dolphin.SetActive(true);
        dolphinInfo.SetActive(true);
    }
    public void SelectKillerFish()
    {
        Clear();
        fish.SetActive(true);
        fishInfo.SetActive(true);
    }
    public void GoBack() {
        enemies.SetActive(false);
        logs.SetActive(false);
        upgrades.SetActive(false);
        terminal.SetActive(true);
    }
    void Clear() {
        //upgrades
        electric.SetActive(false);
        fire.SetActive(false);
        water.SetActive(false);
        gravBoots.SetActive(false);
        tempSuit.SetActive(false);
        missiles.SetActive(false);
        //enemies
        bug.SetActive(false);
        mP.SetActive(false);
        pyro.SetActive(false);
        plume.SetActive(false);
        dolphin.SetActive(false);
        fish.SetActive(false);
        
        //text shit
        electricBeamTutorial.SetActive(false);
        tempSuitTutorial.SetActive(true);
        gravBootsTutorial.SetActive(true);
        waterBeamTutorial.SetActive(true);
        missileTutorial.SetActive(true);
        fireBeamTutorial.SetActive(true);

        fishInfo.SetActive(true);
        dolphinInfo.SetActive(true);
        plumeInfo.SetActive(true);
        pyroInfo.SetActive(true);
        mPInfo.SetActive(true);
        bugInfo.SetActive(true);
        
    }
}

