using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public string gameScene;

    public GameObject upgradeMenu;

    public GameObject menuUI;

    public List<GameObject> ballTypes = new List<GameObject>();

    public Text ballUpgrade;

    public float defaultBallCost;

    public float upgradeMultiplyer;

    private int currentBall = 0;

    private float currentCost;

    public void StartButton()
    {
        
        SceneManager.LoadScene(gameScene);
        ballUpgrade.text = "Better ball cost: " + currentCost;
    }

    public void OpenUpgradeMenu()
    {
        menuUI.SetActive(false);
        upgradeMenu.SetActive(true);
    }

    public void CloseUpgradeMenu()
    {
        menuUI.SetActive(true);
        upgradeMenu.SetActive(false);
    }

    public void UpgradeBall()
    {
        if (GameManager.Instance.currency > currentCost)
        {
            GameManager.Instance.currency -= Mathf.RoundToInt(currentCost);
            currentBall++;
            GameManager.Instance.cannonBall = ballTypes[currentBall];
            currentCost = currentCost * upgradeMultiplyer;
            ballUpgrade.text = "Better ball cost: " + currentCost;
        }
    }
}
