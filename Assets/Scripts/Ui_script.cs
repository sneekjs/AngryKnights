using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui_script : MonoBehaviour
{

    public bool upgrades;
    public GameObject mainMenu;
    public GameObject upgradeMenu;

    void Update()
    {
        if(upgrades)
        {
            upgradeMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            upgradeMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToUpgrades()
    {
        upgrades = !upgrades;
    }

    public void DoExitGame() 
    {
        Application.Quit();
    }
}
